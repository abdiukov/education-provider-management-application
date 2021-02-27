using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for SubjectsWithNoCourse.xaml
    /// </summary>
    public partial class SubjectsWithNoCourse : Window
    {

        public SubjectsWithNoCourse()
        {
            InitializeComponent();

        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new CourseInformation());
            this.Visibility = Visibility.Hidden;
        }

        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            int selected_page = dgBreadcrmbs.SelectedIndex;

              PageNavigation.GoToExistingPage(selected_page);
              this.Visibility = Visibility.Hidden;
            
            dgBreadcrmbs.CancelEdit();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                dgBreadcrmbs.ItemsSource = null;
                dgBreadcrmbs.ItemsSource = MainWindow.pagesVisitedTracker;


            }

        }
    }
}
