using System.Windows;
using System.Windows.Controls;

namespace UI.Teacher
{
    public partial class TeacherProfile : Window
    {
        //INITIALISATION CODE
        public TeacherProfile()
        {
            InitializeComponent();
            Title = "Teacher's name goes here";
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
        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new TeacherInformation());
        }

        private void Btn_teacherCourseHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            //  PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
        }

        private void dgTeacherProfile_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgTeacherProfile);
            page.Show();
        }

        //END OF NAVIGATION CODE
    }
}
