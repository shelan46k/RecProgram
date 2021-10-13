using Microsoft.Win32;
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

namespace RecProgram
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        private int 差異天;
        private int 差異時;
        private int 差異分;
        private int 差異秒;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void MenuItem_Click_關閉程式(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            System.Windows.Threading.DispatcherTimer ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
        }
        public void ShowCurTimer(object sender, EventArgs e)
        {
            DateTime a = new DateTime(
                Properties.Settings.Default.設定日期年,
                Properties.Settings.Default.設定日期月,
                Properties.Settings.Default.設定日期日,
                Properties.Settings.Default.設定時間時,
                Properties.Settings.Default.設定時間分,
                Properties.Settings.Default.設定時間秒
            );

            TimeSpan ts = new TimeSpan(a.Ticks - DateTime.Now.Ticks);
            差異天 = ts.Days;
            差異時 = ts.Hours;
            差異分 = ts.Minutes;
            差異秒 = ts.Seconds;
            mainVM.天 = 差異天.ToString();
            mainVM.時 = 差異時.ToString();
            mainVM.分 = 差異分.ToString();
            mainVM.秒 = 差異秒.ToString();
            mainVM.OnChangeAll();
            if (差異天 > 30)
            {
                runningblock_跑馬燈.Content = "時間倒數ing~~~!!!!!";
                runningblock_跑馬燈.Foreground = Brushes.Red;
            }
            else if (差異天 <= 30 && 差異天 > 15)
            {
                runningblock_跑馬燈.Content = $"時間倒數ing~~~就剩下 {差異天} 天啦~~~!!!!!";
            }
            else if (差異天 <= 15 && 差異天 >= 7)
            {
                runningblock_跑馬燈.Content = "時間倒數ing~~~你知道剩下不到半個月嗎~~~!!!!!";
            }
            else if (差異天 == 6)
            {
                runningblock_跑馬燈.Content = "時間倒數ing~~~剩下一個禮拜你知道嗎!!!";
            }
            else if (差異天 == 5)
            {
                runningblock_跑馬燈.Content = "該好好準備交接囉!!!!!";
            }
            else if (差異天 <= 4 && 差異天 >= 2)
            {
                runningblock_跑馬燈.Content = "該揪團吃飯囉!!!!!!!!!!!";
            }
            else if (差異天 == 1)
            {
                runningblock_跑馬燈.Content = "就是明天啦!!!!!!!!!!!";

            }


        }

        private void MenuItem_Click_設定時間(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.Dialog.Show(new 設定時間UserControl());
        }


    }
}
