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
    /// Логика взаимодействия для PageSearchBook.xaml
    /// </summary>
    public partial class PageSearchBook : Page
    {
        public PageSearchBook()
        {
            InitializeComponent();

            DbContext db = new DbContext(MainWindow.path);

            var books = db.GetBooks();

            foreach (Book book in books)
            {
                WrapPanel wp = new WrapPanel();
                Label lb1 = new Label() { Width = 30, Content = book.Id };
                Label lb2 = new Label() { Width = 300, Content = book.Name };
                Label lb3 = new Label() { Width = 150, Content = book.Author };
                Label lb4 = new Label() { Width = 150, Content = book.CreatedDate };

                wp.Children.Add(lb1);
                wp.Children.Add(lb2);
                wp.Children.Add(lb3);

                ListFoundBooks.Items.Add(wp);
            }
        }

        private void BtnBookSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBackMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new PageMainMenu());
        }

        private void ListFoundBooks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StackPanel sp = ((ListBox)sender).SelectedItem as StackPanel;

            int id = Convert.ToInt32(((Label)sp.Children[0]).Content);

            DbContext db = new DbContext(MainWindow.path);

            Book book = db.GetBookById(id);
            if (book != null)
            {
                MainWindow._MainFrame.Navigate(new PageAddBook(book));
            }
            else
            {
                MessageBox.Show("Что-то пошло не так :)");
            }
        }
    }
}
