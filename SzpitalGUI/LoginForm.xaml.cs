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
    /// Logika interakcji dla klasy LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string GetUsername()
        {
            return Username.Text;
        }

        public string GetPassword()
        {
            return Password.Password;
        }

        void CheckInput()
        {
            if (Password != null)
            {
                if (!Password.Password.ToString().Equals("") && !Username.Text.Equals(""))
                {
                    //LoginButton.IsEnabled = true;
                }
            }
            else
            {
                //LoginButton.IsEnabled = false;
            }
        }

        private void Username_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CheckInput();
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckInput();
        }
    }
}