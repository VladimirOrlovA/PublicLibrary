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
    public partial class PageAddBook : Page
    {
        DbContext dbContext = new DbContext(MainWindow.path);
        Book _book = null;
        public PageAddBook(Book book)
        {
            InitializeComponent();

            if (book != null)
            {
                _book = book;
                BtnAddBookOk.Content = "Редактировать";
                BtnAddBookOk.Click += EditBook_Click;
                BtnAddBookOk.Click -= BtnAddBookOk_Click;

                TbBookName.Text = book.Name;
                CbBookEdition.SelectedValue = book.Edition;
                DpBookCreatedDate.SelectedDate = book.CreatedDate;
                TbBookAuthor.Text = book.Author;
                CbBookGenre.SelectedValue = book.Genre;
                rbAvailable.IsChecked = book.IsAvailable;
                CbAfter18.IsChecked = book.IsEighteenPlus;
                CbOld.IsChecked = book.IsRaritet;
                CbLastBook.IsChecked = book.IsLastBook;
                MainWindow.user.Id = book.AddedBy;
                // = book.AddedTime;
            }
            else
            {
                BtnAddBookOk.Content = "Добавить книгу";
                BtnAddBookOk.Click -= EditBook_Click;
                BtnAddBookOk.Click += BtnAddBookOk_Click;
            }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            _book.Name = TbBookName.Text;
            _book.Edition = CbBookEdition.SelectedValue == null ? "не указан" : CbBookEdition.Text;
            _book.CreatedDate = DpBookCreatedDate.SelectedDate != null ? (DateTime)DpBookCreatedDate.SelectedDate : DateTime.Now;
            _book.Author = TbBookAuthor.Text;
            _book.Genre = CbBookGenre.SelectedValue == null ? "нет" : CbBookGenre.SelectedValue.ToString();
            _book.IsAvailable = (bool)rbAvailable.IsChecked;
            _book.IsEighteenPlus = (bool)CbAfter18.IsChecked;
            _book.IsRaritet = (bool)CbOld.IsChecked;
            _book.IsLastBook = (bool)CbLastBook.IsChecked;
            _book.AddedBy = MainWindow.user.Id;
            _book.AddedTime = DateTime.Now;

            if (dbContext.EditBook(_book))
            {
                MessageBox.Show("Книга изменена успешно!");
                MainWindow._MainFrame.Navigate(new PageMainMenu());
            }
            else
            {
                MessageBox.Show("Возникли ошибки при изменении книги!");
            }

        }

        private void BtnAddBookOk_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();

            book.Name = TbBookName.Text;
            book.Edition = CbBookEdition.SelectedValue == null ? "не указан" : CbBookEdition.Text;
            book.CreatedDate = DpBookCreatedDate.SelectedDate != null ? (DateTime)DpBookCreatedDate.SelectedDate : DateTime.Now;
            book.Author = TbBookAuthor.Text;
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


        private void BtnAddBookCancel_Click(object sender, RoutedEventArgs e)
        {

        }


        private void BtnBackMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new PageMainMenu());
        }

    }
}
