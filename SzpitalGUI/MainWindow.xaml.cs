using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Szpital;

namespace SzpitalGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                LoadDatabase();
            }
            catch (IOException e)
            {
                usersList = new UsersList();
                workShiftList = new WorkShiftList();
                usersList.AddUser("admin", "admin", new Administrator(new PersonalData("admin", "admin", "")));
            }


            WorkShiftCalendar.SelectedDate = DateTime.Today;
            //SaveDatabase();

        }

        void LoadDatabase()
        {
            Wrapper wrapper = Serializer.Load<Wrapper>("database.bin");
            usersList = wrapper.UsersList;
            workShiftList = wrapper.WorkShiftList;
        }

        public void SaveDatabase()
        {
            Wrapper wrapper = new Wrapper(this.usersList, this.workShiftList);
            Serializer.Save("database.bin", wrapper);
        }

        private User currentUser;
        private UsersList usersList;
        private WorkShiftList workShiftList;

        void ShowUsers()
        {
            List<UserDataGetter> userData = new List<UserDataGetter>();
            foreach (var user in usersList.Users)
            {
                userData.Add(new UserDataGetter(user));
            }

            UsersListView.ItemsSource = userData;
        }

        void ShowWorkShift()
        {
            if (WorkShiftCalendar.SelectedDate.HasValue)
            {
                DateTime date = WorkShiftCalendar.SelectedDate.Value;
                WorkShift workShift = workShiftList.GetWorkShift(date);
                if (workShift != null)
                {
                    var users = workShift.Users;
                    List<UserDataGetter> userData = new List<UserDataGetter>();
                    foreach (var user in users)
                    {
                        userData.Add(new UserDataGetter(user));
                    }

                    WorkShiftListView.ItemsSource = userData;
                }
                else
                {
                    WorkShiftListView.ItemsSource = null;
                }
            }
        }


        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            SaveDatabase();
        }

        private void AddUser_OnClick(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            if (addUserWindow.ShowDialog() == true)
            {
                User user = addUserWindow.GetUser();
                try
                {
                    usersList.AddUser(user);
                    ShowUsers();
                }
                catch (UserAlreadyExistException exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            if (UsersListView.SelectedItem is UserDataGetter userData)
            {
                try
                {
                    workShiftList.RemoveEmployeeWholeRange(usersList.GetUser(userData.Username));
                    usersList.RemoveUser(userData.Username);
                    ShowUsers();
                    ShowWorkShift();
                }
                catch (UserDoesNotExistException exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
//            ShowWorkShift();
//            ShowUsers();
        }

        private void AssignWorkShift_OnClick(object sender, RoutedEventArgs e)
        {
            List<UserDataGetter> userData = new List<UserDataGetter>();
            foreach (var user in usersList.Users)
            {
                if (user.EmployeeType.Role != Role.Administrator)
                {
                    userData.Add(new UserDataGetter(user));
                }
            }

            AddWorkShift addWorkShift = new AddWorkShift(userData);
            if (addWorkShift.ShowDialog() == true)
            {
                //.addWorkShift.GetUsername();
                if (WorkShiftCalendar.SelectedDate != null)
                {
                    try
                    {
                        workShiftList.AssignEmployee(usersList.GetUser(addWorkShift.GetUsername()),
                            WorkShiftCalendar.SelectedDate.Value);
                        ShowWorkShift();
                    }
                    catch (EmployeeAlreadyAssignedException exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (SpecialityAlreadyAssignedException exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (MonthylAssignmentExceeded exception)
                    {
                        MessageBox.Show(exception.Message, "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void RemoveWorkShift_OnClick(object sender, RoutedEventArgs e)
        {
            if (WorkShiftListView.SelectedItem is UserDataGetter userData)
            {
                try
                {
                    if (WorkShiftCalendar.SelectedDate != null)
                    {
                        workShiftList.RemoveEmployee(usersList.GetUser(userData.Username),
                            WorkShiftCalendar.SelectedDate.Value);
                        ShowWorkShift();
                    }
                }
                catch (EmployeeIsNotAssignedException exception)
                {
                    MessageBox.Show(exception.Message, "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void WorkShiftCalendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowWorkShift();
        }


        private void MainWindow_OnContentRendered(object sender, EventArgs e)
        {
            //LoginValidator
            bool loggedIn = false;

            while (!loggedIn)
            {
                LoginForm login = new LoginForm();
                if (login.ShowDialog() == true)
                {
                    loggedIn = LoginValidator.ValidateLoginInput(login.GetUsername(), login.GetPassword(), usersList);
                    try
                    {
                        currentUser = usersList.GetUser(login.GetUsername());
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            ShowWorkShift();
            ShowUsers();

            if (currentUser.EmployeeType.Role != Role.Administrator)
            {
                AddUser.Visibility = System.Windows.Visibility.Hidden;
                RemoveUser.Visibility = System.Windows.Visibility.Hidden;
                AssignWorkShift.Visibility = System.Windows.Visibility.Hidden;
                RemoveWorkShift.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}