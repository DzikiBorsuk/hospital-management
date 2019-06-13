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

namespace SzpitalGUI
{
    /// <summary>
    /// Logika interakcji dla klasy AddWorkShift.xaml
    /// </summary>
    public partial class AddWorkShift : Window
    {
        public AddWorkShift()
        {
            InitializeComponent();
        }

        private List<UserDataGetter> usersData;

        public AddWorkShift(List<UserDataGetter> usersData) : this()
        {
            this.usersData = usersData;
            WorkShiftListView.ItemsSource = usersData;
        }

//        bool CheckIfSelected()
//        {
//
//        }

        public string GetUsername()
        {
            if (WorkShiftListView.SelectedItem is UserDataGetter userData)
            {
                return userData.Username;
            }

            return null;
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
