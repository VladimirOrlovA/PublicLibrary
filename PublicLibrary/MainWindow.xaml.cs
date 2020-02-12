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
using PublicLibrary.Pages;

namespace PublicLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        //public static string path = @"DB\publicLibraryData.db";
        public static string path = @"C:\Users\vladi\Source\Repos\PublicLibrary\PublicLibrary\DB\publicLibraryData.db";
        public static User user = null;
        public static Frame _MainFrame = null;
        private DbContext db = new DbContext(path);
     
        public MainWindow()
        {
            InitializeComponent();
            _MainFrame = MainFrame;
            MainFrame.Navigate(new PageAuth());
        }

    }
}
