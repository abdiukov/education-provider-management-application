using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    public partial class StudentEnrolment : Window
    {

        //INITIALISATION CODE
        public StudentEnrolment(int studentID)
        {
            InitializeComponent();
            dgStudentEnrolment.ItemsSource = App.logic.GetEnrolmentsByID(studentID);
            this.Title = "Enrolments for ID " + studentID;

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
            Hide();
            PageNavigation.GoToExistingPage(new StudentInformation());
        }
        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void dgStudentEnrolment_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(dgStudentEnrolment);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
