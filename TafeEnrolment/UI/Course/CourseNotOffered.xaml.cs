using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Shows a datagrid which contains infromation about all the coures that are currently nto being taught.
    /// </summary>
    public partial class CourseNotOffered : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the datagrid to be retrieved from Control.cs method AllNotOfferedCourses();
        /// </summary>
        public CourseNotOffered()
        {
            InitializeComponent();
            DgCourseNotOffered.ItemsSource = App.logic.GetFromDB("AllNotOfferedCourses");
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //PAGE NAVIGATION CODE
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0);
        }
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        //DATAGRID SETTINGS CODE
        private void DgCourseNotOffered_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgCourseNotOffered);
            page.Show();
        }

    }
}
