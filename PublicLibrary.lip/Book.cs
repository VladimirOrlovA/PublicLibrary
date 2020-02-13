using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.lib
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public  DateTime  CreatedDate{ get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsEighteenPlus { get; set; }
        public bool IsRaritet { get; set; }
        public bool IsLastBook { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedTime { get; set; }
    }
}
