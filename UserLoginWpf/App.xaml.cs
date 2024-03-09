using System.Windows;
using UserLoginWpf.ViewModels;
using UserLoginWpf.Views;

namespace UserLoginWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

       protected void ApplicationStart(object sender, EventArgs e)
       {
            var loginWindow = new LoginView();
            loginWindow.Show();

            loginWindow.IsVisibleChanged += (s, e) =>
            {
                if (loginWindow.IsLoaded && loginWindow.IsVisible == false)
                {
                    MainViewModel mainViewModel = new MainViewModel();

                    var mainWindow = new MainWindow();
                    mainWindow.Show();

                    loginWindow.Close();
                }
            };
       }
    }
}
