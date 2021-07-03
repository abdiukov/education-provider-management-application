using System.Windows;
using System.Windows.Controls;

namespace UI
{
    public partial class CourseNotOffered : Window
    {
        //INITIALISATION CODE
        public CourseNotOffered()
        {
            InitializeComponent();
            dgCourseNotOffered.ItemsSource = App.logic.GetFromDB("AllNotOfferedCourses");
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
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new CourseInformation());
        }
        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }


        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void dgCourseNotOffered_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgCourseNotOffered);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE



    }
}
