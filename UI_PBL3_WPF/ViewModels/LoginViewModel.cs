using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI_PBL3_WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields 
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        //Properties
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        //Command
        public ICommand LoginCommand { get; }
        public ICommand RecoverPassWordCommand { get; }
        public ICommand ShowPassWordCommand { get; }
        public ICommand RemmenberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExeceuteLoginCommand, CanExecuteLoginCommand);
            RecoverPassWordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else validData = true;

            return validData;
        }

        private void ExeceuteLoginCommand(object obj)
        {
            throw new NotImplementedException();
        }
        private void ExecuteRecoverPasswordCommand(string username, string pwd)
        {
            throw new NotImplementedException();
        }
    }
}
