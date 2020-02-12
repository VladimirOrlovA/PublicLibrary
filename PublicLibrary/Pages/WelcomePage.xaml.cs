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
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void BtnAddBookCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddBookOk_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();

            book.Name = TbBookName.Text;
            book.Edition = CbBookEdition.SelectedValue == null ? "не указан" : CbBookEdition.Text;
            book.CreatedDate = DpBookCreatedDate.SelectedDate != null ? (DateTime)DpBookCreatedDate.SelectedDate : DateTime.Now;
            book.Autor = TbBookAuthor.Text;
            book.Genre = CbBookGenre.SelectedValue == null ? "нет" : CbBookGenre.SelectedValue.ToString();
            book.IsAvailable = (bool)rbAvailable.IsChecked;
            book.IsEighteenPlus = (bool)CbAfter18.IsChecked;
            book.IsRaritet = (bool)CbOld.IsChecked;
            book.IsLastBook = (bool)CbLastBook.IsChecked;
            book.AddedBy = MainWindow.user.Id;
            book.AddedTime = DateTime.Now;

            DbContext db = new DbContext(MainWindow.path);

            if (!db.AddBook(book))
            {
                MessageBox.Show("Не удалось добавить книгу");
            }
            else MessageBox.Show("Книга добавлена");


        }
    }
}
