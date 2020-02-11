﻿using PublicLibrary.lip;
using PublicLibrary.Pages;
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

namespace PublicLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string path = @"C:\Temp\MyData.db";
        public static User user = null;

        private DBcontext db = new DBcontext(path);
     
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new PageAuth());
        }

    }
}
