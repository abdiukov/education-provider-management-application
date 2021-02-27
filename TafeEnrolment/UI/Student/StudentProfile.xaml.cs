using System.Windows;
using System.Windows.Controls;

namespace UI.Student
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : Window
    {

        public StudentProfile()
        {
            InitializeComponent();
            Title = "Student's name goes here";

        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentInformation());
            this.Visibility = Visibility.Hidden;
        }

        private void Btn_StudentEnrolment_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentEnrolment());
            this.Visibility = Visibility.Hidden;
        }

        private void Btn_StudentResult_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new StudentResultSearch());
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
