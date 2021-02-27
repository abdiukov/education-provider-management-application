using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for CourseInformation.xaml
    /// </summary>
    public partial class CourseInformation : Window
    {

        public CourseInformation()
        {
            InitializeComponent();

        }

        private void courseTimetables_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseTimetableSearch());
            this.Visibility = Visibility.Collapsed;
        }


        //navigation
        private void clusterUnitCourse_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new SubjectsClustered());
            this.Visibility = Visibility.Collapsed;
        }

        private void courseNotOffered_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseNotOffered());
            this.Visibility = Visibility.Collapsed;
        }

        private void subjectsNotAllocated_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new SubjectsWithNoCourse());
            this.Visibility = Visibility.Collapsed;
        }

        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0);
            this.Visibility = Visibility.Collapsed;
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
            this.Visibility = Visibility.Collapsed;

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;

            }

        }
    }
}
