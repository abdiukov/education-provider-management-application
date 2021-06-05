using ModelLayer;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Logic logic = new Logic();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Btn_AttemptLogin_Click(object sender, RoutedEventArgs e)
        {
            AttemptLogin();
        }

        private void PasswordBox_Password_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AttemptLogin();
            }
        }


        private void AttemptLogin()
        {
            if (logic.AttemptLogin(Textbox_Username.Text, PasswordBox_Password.Password))
            {
                MainWindow pageobj = new MainWindow();
                pageobj.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect. Please try again.");
                MessageBox.Show("This is a demo application.\nUsername - 'admin'. Password - 'password'");
            }
        }
    }
}
