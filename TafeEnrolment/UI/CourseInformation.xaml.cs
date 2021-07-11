using System;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Displays buttons that redirect to course-related pages.
    /// </summary>
    public partial class CourseInformation : Window
    {
        public CourseInformation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the navigation bar at the top, whenever the window visibility changes
        /// </summary>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        private void CourseTimetables_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseTimetableSearch(), this);
        }

        private void ClusterUnitCourse_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new SubjectsClustered(), this);
        }

        private void CourseNotOffered_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseNotOffered(), this);
        }

        private void SubjectsNotAllocated_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new SubjectsWithNoCourse(), this);
        }

        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0, this);
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
