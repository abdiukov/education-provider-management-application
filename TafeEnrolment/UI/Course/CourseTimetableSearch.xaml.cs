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

        //NAVIGATION CODE

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new CourseInformation());
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }
        //END OF NAVIGATION CODE

        //SEARCH DATAGRID CODE

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            PageLogic.SearchCourseTimetable(SearchBox.Text);
        }

        private void SearchBox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            PageLogic.SearchBoxReplaceDefaultValue(SearchBox.Text);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }


        //END OF SEARCH DATAGRID CODE


        //DATAGRID SETTINGS CODE

        private void dgTimetable_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        //END OF DATAGRID SETTINGS CODE
    }
}
