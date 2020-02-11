using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.lip
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
                return false;
            }
        }
    }
}
