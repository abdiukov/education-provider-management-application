using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Shows a datagrid which contains infromation 
    /// </summary>
    public partial class SubjectsClustered : Window
    {

        public SubjectsClustered()
        {
            InitializeComponent();
            DgClusteredUnits.ItemsSource = App.logic.GetFromDB("GetClusters");
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
            PageNavigation.GoToExistingPage(0);
        }

        /// <summary>
        /// When the page on the navigation bar at the top is clicked upon, this page gets hidden and the user is redirected to that page
        /// </summary>
        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        //END OF NAVIGATION CODE


        //DATAGRID SETTINGS CODE

        private void DgClusteredUnits_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgClusteredUnits);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE

    }
}
