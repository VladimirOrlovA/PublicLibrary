using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.lip
{
    public class DBcontext
    {
        public string Path { get; set; } = @"C:\Temp\MyData.db";

        public DBcontext(string Path)
        {
            this.Path = Path;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(Path))
            {
                users = db.GetCollection<User>("User").FindAll().ToList();
            }

            return users;
        }

        public User GetUser()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(Path))
            {
                users = db.GetCollection<User>("User").FindAll().ToList();
            }

            User user = new User();

            return user;
        }

        public bool RegUser(User user)
        {
            using(var db = new LiteDatabase(Path))
            {
                var users = db.GetCollection<User>("User");
                users.Insert(user);
                return false;
            }
        }
    }
}
