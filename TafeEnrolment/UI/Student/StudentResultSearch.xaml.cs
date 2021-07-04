using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Student
{
    public partial class StudentResultSearch : Window
    {

        //INITIALISATION CODE
        public StudentResultSearch(int studentID)
        {
            InitializeComponent();
            DgStudentResults.ItemsSource = App.logic.GetFromDB("GetStudentResults", new object[] { studentID });
            this.Title = "Results for ID " + studentID;
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
        //END OF INITIALISATION CODE

        //NAVIGATION CODE        /// <summary>
        /// When the arrow button (located top left) is clicked, user is redirected to main menu
        /// </summary>
        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToExistingPage(0);
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
            Hide();
        }

        //END OF NAVIGATION CODE

        //DATAGRID SETTINGS CODE

        private void DgStudentResults_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgStudentResults);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE


    }
}
