using System;
using System.Reflection;
using System.Windows;
namespace RecProgram
{
    /// <summary>
    /// 設定時間UserControl.xaml 的互動邏輯
    /// </summary>
    public partial class 設定時間UserControl
    {
        public 設定時間UserControl()
        {
            InitializeComponent();
            DateTime a = new DateTime(
                Properties.Settings.Default.設定日期年,
                Properties.Settings.Default.設定日期月,
                Properties.Settings.Default.設定日期日,
                Properties.Settings.Default.設定時間時,
                Properties.Settings.Default.設定時間分,
                Properties.Settings.Default.設定時間秒
                );
            dtp.SelectedDateTime = a;
        }

        private void Button_Click_確認(object sender, RoutedEventArgs e)
        {
            DateTime timeconfig = new DateTime();


            timeconfig = (DateTime)dtp.SelectedDateTime;
            if (timeconfig > DateTime.Now)
            {
                Properties.Settings.Default.設定日期年 = timeconfig.Year;
                Properties.Settings.Default.設定日期月 = timeconfig.Month;
                Properties.Settings.Default.設定日期日 = timeconfig.Day;
                Properties.Settings.Default.設定時間時 = timeconfig.Hour;
                Properties.Settings.Default.設定時間分 = timeconfig.Minute;
                Properties.Settings.Default.設定時間秒 = timeconfig.Second;
                Properties.Settings.Default.已設定 = true;
                Properties.Settings.Default.Save();
                Btnclose.OnClick();
            }
            else
            {
                MessageBox.Show("請輸入大於目前時間!!!!!");
            }
        }
    }
    public static class ButtonBaseExtension
    {
        /// <summary>
        /// 引发 <see>
        /// <cref>Primitives.ButtonBase.Click</cref>
        /// </see>
        /// 路由事件。
        /// </summary>
        /// <param name="buttonBase">要引发路由事件的按钮</param>
        public static void OnClick(this System.Windows.Controls.Primitives.ButtonBase buttonBase)
        {
            buttonBase.GetType().GetMethod(nameof(OnClick), BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(buttonBase, null);
        }
    }
}
