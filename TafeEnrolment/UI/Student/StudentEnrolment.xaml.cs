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
            DgStudentEnrolment.ItemsSource = App.logic.GetFromDB("GetEnrolmentsByID", new object[] { studentID });
            this.Title = "Enrolments for ID " + studentID;

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }
        //END OF INITIALISATION CODE

        //NAVIGATION CODE

        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new StudentInformation());
        }
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void DgStudentEnrolment_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgStudentEnrolment);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
