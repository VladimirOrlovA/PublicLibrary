using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.lip
{
    public class SomeThinth
    {
        public string Path { get; set; } = @"C:\Temp\MyData.db";
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (var db = new LiteDatabase(Path))
            {
                users = db.GetCollection<User>("User").FindAll().ToList();
            }

            return users;
        }


    }
}
