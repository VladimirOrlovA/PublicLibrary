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
using System.Windows.Navigation;
using System.Windows.Shapes;

using PublicLibrary.lib;

namespace PublicLibrary.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        private DbContext db = new DbContext(MainWindow.path);
        public PageAuth()
        {
            InitializeComponent();
        }

        private void BtnEnt_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInput("inputVal", "errField"))
            {
                MainWindow.user = db.GetUser(PbInputPassword.Password, TbInputLogin.Text);

                if (MainWindow.user != null)
                {
                    MainWindow._MainFrame.Navigate(new PageMainMenu());
                }
                else
                {
                    MessageBox.Show("Ошибка авторизации");
                }
            }
        }

        private void TbInputLogin_KeyDown(object sender, KeyEventArgs e)
        {
            string inputStr = TbInputLogin.Text;
            CheckInput(inputStr, "LbInputLoginErrMess");
        }

        private void TbInputLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            string inputStr = TbInputLogin.Text;
            CheckInput(inputStr, "LbInputLoginErrMess");
        }


        private void PbInputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            string inputStr = PbInputPassword.Password;
            CheckInput(inputStr, "LbInputPasswordErrMess");
        }

        private void PbInputPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            string inputStr = PbInputPassword.Password;
            CheckInput(inputStr, "LbInputPasswordErrMess");
        }

        private bool CheckInput(string inputVal, string errField)
        {
            if (string.IsNullOrWhiteSpace(inputVal) && errField == "LbInputLoginErrMess")
            {
                LbInputLoginErrMess.Content = "Поле обязательное для заполнения!";
                LbInputLoginErrMess.Foreground = new SolidColorBrush(Colors.Red);
                TbInputLogin.BorderBrush = Brushes.Red;
                return false;
            }

            if (string.IsNullOrWhiteSpace(inputVal) && errField == "LbInputPasswordErrMess")
            {
                LbInputPasswordErrMess.Content = "Поле обязательное для заполнения!";
                LbInputPasswordErrMess.Foreground = new SolidColorBrush(Colors.Red);
                PbInputPassword.BorderBrush = Brushes.Red;
                return false;
            }

            LbInputLoginErrMess.Content = LbInputPasswordErrMess.Content = "";
            return true;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
        }
    }
}
