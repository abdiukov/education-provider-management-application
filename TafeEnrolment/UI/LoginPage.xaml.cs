using ModelLayer;
using System.Windows;
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

            if (logic.AttemptLogin(Textbox_Username.Text, PasswordBox_Password.Password))
            {
                MainWindow pageobj = new MainWindow();
                pageobj.Show();
                this.Close();

            }
            //PasswordBox_Password.Password
        }
    }
}
