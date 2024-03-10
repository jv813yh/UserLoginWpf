using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace UserLoginWpf.CustomControls
{
    /// <summary>
    /// Interaction logic for BindingAblePassword.xaml
    /// </summary>
    public partial class BindingAblePassword : UserControl
    {
        public static readonly DependencyProperty PasswordProperty
            = DependencyProperty.Register("Password", typeof(SecureString), typeof(BindingAblePassword));

        public BindingAblePassword()
        {
            InitializeComponent();

            pswPasswordBox.PasswordChanged += OnPasswordChanged;
        }
        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set{ SetValue(PasswordProperty, value); }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = pswPasswordBox.SecurePassword;
        }
    }
}
