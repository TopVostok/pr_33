using System;
using System.Windows;
using System.Windows.Controls;
using ChatStudents.Models;

namespace ChatStudents
{
    public partial class MainWindow : Window
    {
        // Singleton паттерн
        private static MainWindow _instance;
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }

        public Users LoginUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _instance = this;
        }

        public void OpenPages(Page page)
        {
            MainFrame.Navigate(page);
        }
    }
}