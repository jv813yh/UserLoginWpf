using System.ComponentModel;
using System.Security;
using System.Windows.Input;
using System.Net;
using UserLoginWpf.Interfaces;
using UserLoginWpf.Repositories;
using System.Security.Principal;

namespace UserLoginWpf.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private IUserRepository _userRepository;
        //
        private string _username = string.Empty;

        //
        private SecureString _password;

        //
        private string _errorMessage = "";
        //
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
            _userRepository = new UserRepository();

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);

            //PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            CanExecuteLoginCommand(null);
        }

        private bool CanExecuteLoginCommand(object parameter)
        {
            bool isValidData = false;

            if(Username.Length < 3 || string.IsNullOrEmpty(Username)
                || Password == null)
            {
                if(Password != null)
                {
                    if (Password.Length < 3)
                        isValidData = false;
                }
            }
            else
            {
                isValidData = true;
            }


            return isValidData;
        }

        private void ExecuteLoginCommand(object parameter)
        {
            bool isValidUser = _userRepository.Authenticate(new NetworkCredential(Username, Password));
            
            if(isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }

        private void ExecuteRecoverPasswordCommand(object parameter)
        {

        }
    }
}
