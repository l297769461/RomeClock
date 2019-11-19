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

namespace RomeClock
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddContextMenu();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bor.CornerRadius = new CornerRadius(this.ActualWidth / 2);
            Clock.Show();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void AddContextMenu()
        {
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem();
            mi.Header = "设为置顶";
            mi.Click += Mi_Click1;
            cm.Items.Add(mi);
            Separator separator = new Separator();
            cm.Items.Add(separator);
            mi = new MenuItem();
            mi.Header = "关闭";
            mi.Click += Mi_Click;
            cm.Items.Add(mi);
            this.ContextMenu = cm;
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mi_Click1(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            Topmost = !Topmost;
            item.Header = Topmost ? "取消置顶" : "设为置顶";
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mi_Click(object sender, RoutedEventArgs e)
        {
            Clock.Dispose();
            this.Close();
        }
    }
}
