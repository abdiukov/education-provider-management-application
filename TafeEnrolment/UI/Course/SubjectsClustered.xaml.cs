using System.Windows;
using System.Windows.Controls;

namespace UI
{
    public partial class SubjectsClustered : Window
    {

        //INITIALISATION CODE
        public SubjectsClustered()
        {
            InitializeComponent();
            dgClusteredUnits.ItemsSource = App.logic.GetClusters();
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


        //DATAGRID SETTINGS CODE

        private void dgClusteredUnits_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgClusteredUnits);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE

    }
}
