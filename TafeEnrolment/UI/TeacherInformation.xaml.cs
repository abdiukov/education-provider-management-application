using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Teacher;

namespace UI
{
    /// <summary>
    /// Interaction logic for TeacherInformation.xaml
    /// </summary>
    public partial class TeacherInformation : Window
    {


        //START UP CODE
        public TeacherInformation()
        {
            InitializeComponent();

        }

        /// <summary>
        /// If the window is opened first time /reopened again by user
        /// Then 
        /// 1. Reload the breadcrumbs datagrid
        /// 2. Find the item that is equal to the current page name and add "<-- -->" to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;
            }
        }
        // END OF START UP CODE

        //NAVIGATION CODE

        /// <summary>
        /// When the user clicks on the main button
        /// The user gets redirected to "MainWindow"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new MainWindow());
            this.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// When user clicks on the button to see course history
        /// The user gets redirected to "TeacherCourseHistory"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Btn_CourseHistory_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
            this.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Button redirects to "TeacherProfile"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            this.Visibility = Visibility.Hidden;
        }

        //END OF NAVIGATION CODE

        // SEARCH TEXTBOX CODE

        private void SearchTextbox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextbox.Text == "Enter keywords by which criteria to search")
            {
                SearchTextbox.Text = "";
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //logic to update the datagrid for a specific teacher
            SearchDataGrid(SearchTextbox.Text);

            //below is placeholder code for testing
            PageNavigation.GoToNewOrExistingPage(new TeacherProfile());
            this.Visibility = Visibility.Hidden;
        }

        private void SearchDataGrid(string searchInput)
        {
            searchInput = searchInput == "Enter keywords by which criteria to search" ? "" : searchInput;

            if (checkbox_SearchPartTime.IsChecked == true)
            {
                if (checkbox_SearchTeacherNotBasedLocation.IsChecked == true)
                {
                    MessageBox.Show("Show part time teachers who are not teaching at their base location " + searchInput);
                }
                else
                {
                    MessageBox.Show("Show part time teachers " + searchInput);
                }
            }
            else if (checkbox_SearchFullTime.IsChecked == true)
            {
                if (checkbox_SearchTeacherNotBasedLocation.IsChecked == true)
                {
                    MessageBox.Show("Show full time teachers who are not teaching at their base location " + searchInput);
                }
                else
                {
                    MessageBox.Show("Show full time teachers " + searchInput);
                }
            }
            else if (checkbox_SearchTeacherNotBasedLocation.IsChecked == true)
            {
                MessageBox.Show("Show all teachers who are not teaching at their base location " + searchInput);
            }
            else
            {
                MessageBox.Show("Search everyone " + searchInput);
            }
        }

        private void checkbox_SearchPartTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchFullTime.IsChecked = false;
        }

        private void checkbox_SearchFullTime_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPartTime.IsChecked = false;
        }

        /// <summary>
        /// Displays datagrid settings to the user.
        /// The user can select which parts of the datagrid he wishes to see
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTeacherProfiles_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Upon right clicking, there should be datagrid settings displayed to user");
        }

        /// <summary>
        /// Navigates to the page that the user has selected on at the Breadcrumbs datagrid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            int selected_page = dgBreadcrmbs.SelectedIndex;
            dgBreadcrmbs.CancelEdit();

            PageNavigation.GoToExistingPage(selected_page);
            this.Visibility = Visibility.Hidden;

        }




    }
}
