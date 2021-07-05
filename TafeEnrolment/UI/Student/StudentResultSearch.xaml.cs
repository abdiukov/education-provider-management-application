using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Student
{
    /// <summary>
    /// Shows a datagrid that contains information about all the course results for a specific student
    /// </summary>
    public partial class StudentResultSearch : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the datagrid to be retrieved from Control.cs method GetStudentResults();
        /// </summary>
        /// <param name="studentID">ID of student inside the database e.g 10</param>
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

        /// <summary>
        /// Upon right clicking on the datagrid, the user is presented with the page where they can hide columns in the datagrid
        /// </summary>
        private void DgStudentResults_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgStudentResults);
            page.Show();
        }


    }
}
