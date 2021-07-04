using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class CourseTimetableSearch : Window
    {

        //INITIALISATION CODE
        public CourseTimetableSearch()
        {
            InitializeComponent();
            DgTimetable.ItemsSource = App.logic.GetFromDB("GetTimetables");
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
            PageNavigation.GoToExistingPage(0);
        }


        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }
        //END OF NAVIGATION CODE

        //SEARCH DATAGRID CODE

        //END OF SEARCH DATAGRID CODE


        //DATAGRID SETTINGS CODE

        private void DgTimetable_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgTimetable);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
