using ModelLayer;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class CourseTimetableSearch : Window
    {
        Logic logic = new Logic();
        //INITIALISATION CODE
        public CourseTimetableSearch()
        {
            InitializeComponent();
            dgTimetable.ItemsSource = logic.GetTimetables();
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
            PageNavigation.GoToExistingPage(new CourseInformation());
        }


        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }
        //END OF NAVIGATION CODE

        //SEARCH DATAGRID CODE

        //END OF SEARCH DATAGRID CODE


        //DATAGRID SETTINGS CODE

        private void dgTimetable_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgTimetable);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
