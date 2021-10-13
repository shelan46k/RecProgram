using Microsoft.Win32;
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
            checkbox_自動開機.IsChecked = Properties.Settings.Default.自動開機;
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
                Properties.Settings.Default.自動開機 = (bool)checkbox_自動開機.IsChecked;
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.自動開機)
                {
                    開機自動執行();
                }
                else
                {
                    取消開機自動執行();
                }
                Btnclose.OnClick();
            }
            else
            {
                MessageBox.Show("請輸入大於目前時間!!!!!");
            }
        }
        private void 開機自動執行()
        {
            #region 設定開機自啟
            try
            {
                string strName = AppDomain.CurrentDomain.BaseDirectory + "RecProgram.exe";//獲取要自動執行的應用程式名，也就是本程式的名稱
                if (!System.IO.File.Exists(strName))//判斷要自動執行的應用程式檔案是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);//獲取應用程式檔名，不包括路徑
                RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//檢索指定的子項
                if (registry == null)//若指定的子項不存在
                    registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//則建立指定的子項
                registry.SetValue(strnewName, strName);//設定該子項的新的“鍵值對”
                registry.Close();
                //MessageBox.Show("開機自啟設定成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        private void 取消開機自動執行()
        {
            #region 取消開機自啟
            try
            {
                string strName = AppDomain.CurrentDomain.BaseDirectory + "RecProgram.exe";//獲取要自動執行的應用程式名
                if (!System.IO.File.Exists(strName))//判斷要取消的應用程式檔案是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);///獲取應用程式檔名，不包括路徑
                RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//讀取指定的子項
                if (registry == null)//若指定的子項不存在
                    registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//則建立指定的子項
                registry.DeleteValue(strnewName, false);//刪除指定“鍵名稱”的鍵/值對
                registry.Close();
                //MessageBox.Show("取消開機自啟。");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion

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
