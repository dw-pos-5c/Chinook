using ChinookDbLib;
using ChinookMVVM;
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

namespace Chinook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ChinookContext db;
        private readonly ChinookViewModel vm;

        public MainWindow(ChinookContext db, ChinookViewModel vm)
        {
            InitializeComponent();
            this.db = db;
            this.vm = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.Init(db); 
            this.DataContext = vm;
            FilleTV();
        }

        private void FilleTV()
        {
            var root = new TreeViewItem
            {
                Header = "Test",
            };
            tvMain.Items.Add(root);

            for(int i = 0; i < 10; i++)
            {
                root.Items.Add(new TreeViewItem { Header = new { Test = "Bled" } });
            }
        }

        private void UserControl1_UserControlChanged(object sender, UserControlLib.SliderEventArgs e)
        {
            Console.WriteLine(e.Value);
        }
    }
}
