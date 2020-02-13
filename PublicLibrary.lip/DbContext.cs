using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiteDB;

namespace PublicLibrary.lib
{
    public class DbContext
    {
        public DbContext(string Path)
        {
            this.Path = Path;
        }

        private string Path { get; set; }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(Path))
            {
                users = db.GetCollection<User>("User").FindAll().ToList();
            }

            return users;
        }

        public User GetUser(string pass, string login)
        {
            User user = null;
            using (var db = new LiteDatabase(Path))
            {
                user = db.GetCollection<User>("User")
                         .FindOne(f => f.Login == login && f.Password == pass);
            }

            return user;
        }

        public bool RegUser(User user)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var users = db.GetCollection<User>("User");
                    users.Insert(user);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool AddBook(Book book)
        {
            try
            {
                using (var db = new LiteDatabase(Path))
                {
                    var books = db.GetCollection<Book>("Book");
                    books.Insert(book);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Book> GetBooks()
        {
            List<Book> books = null;

            using (var db = new LiteDatabase(Path))
            {
                books = db.GetCollection<Book>("Book").FindAll().ToList();
                return books;
            }
        }

        public Book GetBookById(int id)
        {
            Book book = new Book();

            using(var ldb = new LiteDatabase(Path))
            {
                book = ldb.GetCollection<Book>("Book").FindById(id);
            }

            return book;
        }

        public int ClearTable(string tableName, out int errMesCode)
        {
            try
            {
                using (var ldb = new LiteDatabase(Path))
                {
                    // таблица БД пустая - errMesCode = 3
                    if (!ldb.CollectionExists(tableName)) return errMesCode = 3;
                    // БД повреждена - errMesCode = 1
                    if (!ldb.DropCollection(tableName)) return errMesCode = 1;
                }
                // данные из таблицы удалены - errMesCode = 2
                return errMesCode = 2;
            }
            catch
            {
                // ошибка доступа к БД - errMesCode = 0
                return errMesCode = 0;
            }
        }
    }
}
