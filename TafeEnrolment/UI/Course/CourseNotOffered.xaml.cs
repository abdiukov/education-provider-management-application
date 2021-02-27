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
        }
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;
            }
        }
        //END OF INITIALISATION CODE

        //PAGE NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new CourseInformation());
        }
        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }
        //END OF PAGE NAVIGATION CODE

    }
}
