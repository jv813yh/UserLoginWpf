using System.Windows;
using UserLoginWpf.Interfaces;
using UserLoginWpf.Models;
using UserLoginWpf.Repositories;

namespace UserLoginWpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // 
        private IUserRepository _userRepository;

        //
        private UserAccount _userAccount;
        public UserAccount UserAccount
        {
            get => _userAccount;
            set 
            { 
                if(UserAccount != value)
                {
                    _userAccount = value;
                    OnPropertyChanged(nameof(UserAccount));
                }
            }
        }

        public MainViewModel()
        {
            _userRepository = new UserRepository();
            UserAccount = new UserAccount();
            LoadCurrentUserAccount();
        }

        //
        private void LoadCurrentUserAccount()
        {
            User? user = null;

            try
            {
                if(Thread.CurrentPrincipal is not null)
                {
                    // Get the current user from the database and set the UserAccount property
                    user = _userRepository.GetByName(Thread.CurrentPrincipal.Identity.Name);
                }
            }
            catch (Exception)
            {
                throw new Exception("There was a problem with loading the user");
            }

            // 
            if(user != null)
            {
                UserAccount.Username = user.Username;
                UserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} in my application";
            }
            else
            {
                UserAccount.DisplayName = "Application could not find the user";
            }
        }
    }
}
