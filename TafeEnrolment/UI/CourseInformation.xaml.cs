using System.Windows;
using System.Windows.Controls;

namespace UI
{
    public partial class CourseInformation : Window
    {
        //INITIALISATION CODE
        public CourseInformation()
        {
            InitializeComponent();
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


        //PAGE NAVIGATION CODE
        private void courseTimetables_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new CourseTimetableSearch());
        }

        private void clusterUnitCourse_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new SubjectsClustered());
        }

        private void courseNotOffered_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new CourseNotOffered());
        }

        private void subjectsNotAllocated_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new SubjectsWithNoCourse());
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new MainWindow());
        }

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }
        //END OF PAGE NAVIGATION CODE
    }
}
