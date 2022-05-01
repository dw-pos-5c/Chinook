using ChinookDbLib;
using ChinookMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly AnotherWindow window;

        public MainWindow(ChinookContext db, ChinookViewModel vm, AnotherWindow window)
        {
            InitializeComponent();
            this.db = db;
            this.vm = vm;
            this.window = window;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vm.Init(db); 
            this.DataContext = vm;
            FilleTV();
            window.test += (sender, val) => Console.WriteLine(val);
            window.Show();
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
            var test = Regex.Match("abc", "a(?<b>b)");
            foreach(Group item in test.Groups)
            {
                if(item.Name.Equals("b"))
                    Console.WriteLine(item);
            }
        }

        private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = sender as ListBoxItem;
            var customer = listBoxItem?.Content as Customer;
            if (customer == null) return;
            Console.WriteLine($"{nameof(ListBoxItem_PreviewMouseLeftButtonDown)} - DoDragDrop Customer {customer}");
            DragDrop.DoDragDrop(lstCustomers, customer, DragDropEffects.Copy);
        }

        private void Label_DragOver(object sender, DragEventArgs e)
        {
            bool isCustomer = e.Data.GetDataPresent(typeof(Customer));
            e.Effects = isCustomer ? DragDropEffects.Copy : DragDropEffects.None;
            e.Handled = true;
            tbTest.Text = e.Data.GetData(typeof(Customer)).ToString();
        }
    }
}
