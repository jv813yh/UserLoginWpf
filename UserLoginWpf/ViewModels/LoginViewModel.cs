using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Windows.Input;
using UserLoginWpf.Interfaces;
using UserLoginWpf.Repositories;

namespace UserLoginWpf.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyDataErrorInfo
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


        private Dictionary<string, List<string>> _propertyToDictionaryErrors;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors
            => _propertyToDictionaryErrors.Any();

        public IEnumerable GetErrors(string? propertyName)
            => _propertyToDictionaryErrors.GetValueOrDefault(propertyName, new List<string>());

        private Dictionary<SecureString, List<string>> _secureStringToDictionaryErrors;

        public event EventHandler<DataErrorsChangedEventArgs>? SecureStringErrorsChanged;
        public bool HasErrorsSecureString
            => _secureStringToDictionaryErrors.Any();

        public IEnumerable GetErrorsFromSecureString(SecureString propertyName)
            => _secureStringToDictionaryErrors.GetValueOrDefault(propertyName, new List<string>());
        public string Username 
        { 
            get => _username; 
            set
            {
                if(_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));

                    _propertyToDictionaryErrors.Remove(nameof(Username));

                    if(string.IsNullOrEmpty(_username))
                    {
                        _propertyToDictionaryErrors.Add(nameof(Username), new List<string> { "Username is required" });
                    }
                    else if(_username.Length < 3)
                    {
                        _propertyToDictionaryErrors.Add(nameof(Username), new List<string> { "Username must be at least 3 characters" });
                    }

                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Username)));
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

                    _secureStringToDictionaryErrors.Remove(Password);

                    if (string.IsNullOrEmpty(_username))
                    {
                        _secureStringToDictionaryErrors.Add(Password, new List<string> { "Password is required" });
                    }
                    else if (_username.Length < 3)
                    {
                        _secureStringToDictionaryErrors.Add(Password, new List<string> { "Password must be at least 3 characters" });
                    }

                    SecureStringErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(Password.ToString()));
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
            _propertyToDictionaryErrors = new Dictionary<string, List<string>>();
            _secureStringToDictionaryErrors = new Dictionary<SecureString, List<string>>();

            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverCommand);
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
               // ExecuteRecoverCommand(null);
            }
        }

        // TBD, need to be fixed !!!
        private void ExecuteRecoverCommand(object? parameter)
        {
            Username = string.Empty;
            Password.Clear();
            Password.Dispose();
            Password = new SecureString();
        }

    }
}
