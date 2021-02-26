using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    /// <summary>
    /// Interaction logic for StudentResultSearch.xaml
    /// </summary>
    public partial class StudentResultSearch : Window
    {

        public StudentResultSearch()
        {
            InitializeComponent();

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentProfile());
            Hide();
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            string selected_page = dgBreadcrmbs.SelectedItem.ToString();

            //if the current page is NOT the page the user has clicked on
            //if (selected_page[0] != '<')
            // {
            // PageNavigation.GoToExistingPage(selected_page);
            //  Hide();
            //}
            dgBreadcrmbs.CancelEdit();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;


            }

        }
    }
}
