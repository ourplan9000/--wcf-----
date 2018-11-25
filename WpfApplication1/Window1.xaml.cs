using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        Stopwatch stopwatch = new Stopwatch();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Restart();
            for(int i=0;i<= 100000000;i++)
            {

            }
          
            stopwatch.Stop();
            var milliseconds = stopwatch.ElapsedMilliseconds;
            MessageBox.Show(milliseconds.ToString());
        }
    }
}
