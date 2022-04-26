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

namespace UserControlLib
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        
        public event EventHandler<SliderEventArgs> UserControlChanged;

        public double Value { get; set; }

        private void sldMain_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UserControlChanged?.Invoke(this, new SliderEventArgs { Value = Value });
            lblMain.Content = Value.ToString();
        }
    }
}