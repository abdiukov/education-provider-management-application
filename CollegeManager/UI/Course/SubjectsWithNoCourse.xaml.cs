using System;
using System.Windows;

namespace View
{
    /// <summary>
    /// Shows a datagrid which contains infromation about units that are not at the moment being taught in any course
    /// </summary>
    public partial class SubjectsWithNoCourse : Window
    {
        /// <summary>
        /// Initialises the page and assigns the contents of the datagrid to be retrieved from Control.cs method GetUnallocatedUnits();
        /// </summary>
        public SubjectsWithNoCourse()
        {
            InitializeComponent();
            DgSubjectNoCourse.ItemsSource = App.logic.GetFromDB("GetUnallocatedUnits");
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
        private void DgNavigationBar_NavigateToSelectedPage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex, this);
        }


        /// <summary>
        /// Upon right clicking on the datagrid, the user is presented with the page where they can hide columns in the datagrid
        /// </summary>
        private void DgSubjectNoCourse_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGridSettings page = new DataGridSettings(DgSubjectNoCourse);
            page.Show();
        }

        /// <summary>
        /// If the main window is not visible, and this window is being closed - shut down the application.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.pagesVisitedTracker[0].Visibility == Visibility.Hidden)
            {
                Environment.Exit(0);
            }
        }
    }
}
