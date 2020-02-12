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
                StackPanel sp = new StackPanel();
                Label lb1 = new Label() { Width = 400, Content = book.Name };
                Label lb2 = new Label() { Width = 180, Content = book.Edition };
                Label lb3 = new Label() { Width = 180, Content = book.Autor };

                sp.Children.Add(lb1);
                sp.Children.Add(lb2);
                sp.Children.Add(lb3);

                LbBooks.Items.Add(sp);
            }
        }
    }
}
