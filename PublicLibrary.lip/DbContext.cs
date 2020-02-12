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
                using(var db=new LiteDatabase(Path))
                {
                    var books = db.GetCollection<Book>("Book");
                    books.Insert(book);
                    return true;
                }
            }
            catch(Exception e)
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
    }
}
