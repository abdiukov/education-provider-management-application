using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If user clicks "Sign in" button, the AttenptLogin() method is called
        /// </summary>
        private void Btn_AttemptLogin_Click(object sender, RoutedEventArgs e)
        {
            AttemptLogin();
        }

        /// <summary>
        /// If used presses "Enter" on their keyboard, the AttenptLogin() method is called 
        /// </summary>
        private void PasswordBox_Password_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AttemptLogin();
            }
        }

        /// <summary>
        /// Gets input from textboxes and provides them onto AttemptLogin() method
        /// </summary>
        private void AttemptLogin()
        {
            if (App.logic.AttemptLogin(Textbox_Username.Text, PasswordBox_Password.Password))
            {
                MainWindow pageobj = new MainWindow();
                pageobj.Show();
                Close();

            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect. Please try again.");
                MessageBox.Show("This is a demo application.\nUsername - 'admin'. Password - 'password'");
            }
        }
    }
}
