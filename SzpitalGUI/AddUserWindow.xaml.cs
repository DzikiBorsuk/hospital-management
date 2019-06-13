using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Szpital;

namespace SzpitalGUI
{
    /// <summary>
    /// Logika interakcji dla klasy AddUser.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();

            var role = Enum.GetValues(typeof(Role));
            Role.ItemsSource = role;

            var speciality = Enum.GetValues(typeof(Speciality));
            Speciality.ItemsSource = speciality;

            CheckInput();
        }

        private void check_input(object sender, TextChangedEventArgs e)
        {
            CheckInput();
        }

        private void check_input(object sender, SelectionChangedEventArgs e)
        {
            CheckInput();
        }

        private void check_input(object sender, RoutedEventArgs e)
        {
            CheckInput();
        }

        void CheckInput()
        {
            Ok.IsEnabled = IsInputValid();
            if (Role.SelectedIndex == -1)
            {
                Speciality.IsEnabled = false;
                PWZ.IsEnabled = false;
            }
            else
            {
                Role role = (Role) Role.SelectedItem;
                if (role != Szpital.Role.Lekarz)
                {
                    Speciality.IsEnabled = false;
                    PWZ.IsEnabled = false;
                }
                else
                {
                    Speciality.IsEnabled = true;
                    PWZ.IsEnabled = true;
                }
            }
        }

        bool IsInputValid()
        {
            var a = Role.SelectedIndex;
            if (Role.SelectedIndex != -1)
            {
                Role role = (Role) Role.SelectedItem;
                if (role == Szpital.Role.Lekarz)
                {
                    return !Username.Text.Equals("") && !Password.Password.Equals("") && !Firstname.Text.Equals("") &&
                           !Lastname.Text.Equals("") && !Address.Text.Equals("") && !PWZ.Text.Equals("") &&
                           Role.SelectedIndex != -1 && Speciality.SelectedIndex != -1;
                }
                else
                {
                    return !Username.Text.Equals("") && !Password.Password.Equals("") && !Firstname.Text.Equals("") &&
                           !Lastname.Text.Equals("") && !Address.Text.Equals("") &&
                           Role.SelectedIndex != -1;
                }
            }

            return false;
        }


        public User GetUser()
        {
            EmployeeBase employee = null;
            Role role = (Role) Role.SelectedItem;
            if (role == Szpital.Role.Administrator)
            {
                employee = new Administrator(new PersonalData(Firstname.Text, Lastname.Text, Address.Text));
            }
            else if (role == Szpital.Role.Pielegniarka)
            {
                employee = new Nurse(new PersonalData(Firstname.Text, Lastname.Text, Address.Text));
            }
            else if (role == Szpital.Role.Lekarz)
            {
                employee = new Doctor(new PersonalData(Firstname.Text, Lastname.Text, Address.Text), PWZ.Text,
                    (Szpital.Speciality) Speciality.SelectedItem);
            }

            return new User(Username.Text, Password.Password, employee);
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}