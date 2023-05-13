using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Demo1.DTO;
using Demo1.Model;
using Demo1.UserInfo;

namespace Demo1.ViewModel
{
    public class Window1Model:BaseViewModel
    {
        private string _Test;
        public string Test
        {
            get
            {
                return _Test;

            }
            set
            {
                _Test= value;
                OnPropertyChanged(nameof(Test));
            }
        }
        public Window1Model()
        {
            string accountID = AccountManager.Instance.GetAccountID();
            Test = AccountManager.Instance.GetUserName(accountID);

        }   
    }
}
