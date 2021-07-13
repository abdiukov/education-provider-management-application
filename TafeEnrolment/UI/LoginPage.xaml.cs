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
        /// Gets username and password, uses it to create the connection string and then checks whether the connection can be made
        /// </summary>
        private void AttemptLogin()
        {
            string connectionString = "Server=tcp:myzureserver.database.windows.net,1433;Initial Catalog=TafeSystem;Persist Security Info=False;" +
                "User ID=" + Textbox_Username.Text +
                ";Password=" + PasswordBox_Password.Password +
                ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=5;";

            App.logic = new Logic(connectionString);

            if (App.logic.CheckConnection() == true)
            {
                MainWindow pageobj = new MainWindow();
                pageobj.Show();
                Close();

            }
            else
            {
                MessageBox.Show("The username or password you entered is incorrect. Please try again.\n" +
                    "This is a demo application.Teacher has access to some commands, manager has access to all commands." +
                    "\nUsername - 'manager'. Password - 'M1password' " +
                    "\nUsername - 'teacher'. Password - 'T1password' ");
            }
        }
    }
}
