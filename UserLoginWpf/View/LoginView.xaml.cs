using System.Windows;
using System.Windows.Input;

namespace UserLoginWpf.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimizeClik(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnCloseClik(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLoginClik(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am here");
        }
    }
}
