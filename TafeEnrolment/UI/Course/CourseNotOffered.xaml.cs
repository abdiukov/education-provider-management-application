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
        //END OF INITIALISATION CODE

        //PAGE NAVIGATION CODE
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new CourseInformation());
        }
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }


        //END OF PAGE NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void DgCourseNotOffered_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgCourseNotOffered);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE



    }
}
