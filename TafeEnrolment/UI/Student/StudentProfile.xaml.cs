using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    public partial class StudentProfile : Window
    {
        //INITIALISATION CODE
        public StudentProfile()
        {
            InitializeComponent();
            Title = "Student's name goes here";
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE

        //NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(new StudentInformation());
            Hide();
        }

        private void Btn_StudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment());
            Hide();
        }

        private void Btn_StudentResult_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch());
            Hide();
        }

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
            Hide();
        }

        private void dgStudentProfile_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgStudentProfile);
            page.Show();
        }
        //END OF NAVIGATION CODE
    }
}
