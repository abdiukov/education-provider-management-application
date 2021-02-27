using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    public partial class StudentResultSearch : Window
    {
        //INITIALISATION CODE
        public StudentResultSearch()
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

        //NAVIGATION CODE
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentProfile());
            Hide();
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
            Hide();
        }

        //END OF NAVIGATION CODE

    }
}
