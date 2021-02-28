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
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = App.pagesVisitedTracker;
            }
        }
        //END OF INITIALISATION CODE

        //PAGE NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new CourseInformation());
        }
        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }


        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void dgCourseNotOffered_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        //END OF DATAGRID SETTINGS CODE



    }
}
