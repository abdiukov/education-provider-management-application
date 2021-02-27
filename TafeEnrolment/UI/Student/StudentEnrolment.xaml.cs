using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    /// <summary>
    /// Interaction logic for StudentEnrolment.xaml
    /// </summary>
    public partial class StudentEnrolment : Window
    {

        public StudentEnrolment()
        {
            InitializeComponent();

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentProfile());
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
