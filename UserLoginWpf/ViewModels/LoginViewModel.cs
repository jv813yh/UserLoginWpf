using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserLoginWpf.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string Username 
        { 
            get => _username; 
            set
            {
                if(_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }  
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string ErrorMessage 
        { 
            get => _errorMessage; 
            set
            {
                if(_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        public bool IsViewVisible 
        { 
            get => _isViewVisible;
            set
            {
                if (_isViewVisible != value)
                {
                    _isViewVisible = value;
                    OnPropertyChanged(nameof(IsViewVisible));
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);
        }
        private bool CanExecuteLoginCommand(object parameter)
        {
            bool isValidData;

            if(Username.Length < 3 || string.IsNullOrEmpty(Username)
                || Password.Length < 3 || Password == null)
            {
                isValidData = false;
            }
            else
            {
                isValidData = true;
            }

            return isValidData;
        }

        private void ExecuteLoginCommand(object parameter)
        {

        }

        private void ExecuteRecoverPasswordCommand(object parameter)
        {

        }
    }
}
