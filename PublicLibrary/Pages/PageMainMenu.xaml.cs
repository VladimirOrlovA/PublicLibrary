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
using PublicLibrary;

namespace PublicLibrary.Pages
{
    /// <summary>
    /// Interaction logic for PageMainMenu.xaml
    /// </summary>
    public partial class PageMainMenu : Page
    {
        public PageMainMenu()
        {
            InitializeComponent();
        }

        private void BtnBookSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new PageSearchBook());
        }

        private void BtnBookAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new PageAddBook());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelBook_Click(object sender, RoutedEventArgs e)
        {
            DbContext db = new DbContext(MainWindow.path);
            if (db.DelBooks())
                MessageBox.Show("Все книги удалены");
            else MessageBox.Show("Что-то пошло не так");
        }

    }
}
