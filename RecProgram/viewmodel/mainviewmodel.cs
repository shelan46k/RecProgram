using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecProgram.viewmodel
{
    public class Mainviewmodel : ViewModelBase
    {
        private string _天;
        private string _時;
        private string _分;
        private string _秒;
        private string _跑馬燈;
        public string 天
        {
            get
            {
                if (!string.IsNullOrEmpty(_天))
                {
                    return _天;
                }
                else
                {
                    return "--";
                }
            }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                    _天 = "0";
                }
                else
                {
                    _天 = value;
                }
            }
        }
        public string 時
        {
            get
            {
                if (!string.IsNullOrEmpty(_時))
                {
                    return _時;
                }
                else
                {
                    return "--";
                }
            }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                    _時 = "0";
                }
                else
                {
                    _時 = value;
                }
            }
        }
        public string 分
        {
            get
            {
                if (!string.IsNullOrEmpty(_分))
                {
                    return _分;
                }
                else
                {
                    return "--";
                }
            }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                    _分 = "0";
                }
                else
                {
                    _分 = value;
                }
            }
        }
        public string 秒
        {
            get
            {
                if (!string.IsNullOrEmpty(_秒))
                {

                    return _秒;
                }
                else
                {
                    return "--";
                }
            }
            set
            {
                if (Convert.ToInt32(value) < 0)
                {
                    _秒 = "0";
                }
                else
                {
                    _秒 = value;
                }
            }
        }
        public string 跑馬燈
        {
            get
            {


                return _跑馬燈;
            }
            set
            {
                _跑馬燈 = value;
            }
        }
        public void OnChange(string a)
        {
            OnPropertyChanged(a);
        }
        public void OnChangeAll()
        {
            OnChange("天");
            OnChange("時");
            OnChange("分");
            OnChange("秒");
        }
    }

}
