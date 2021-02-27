using System.Windows;
using System.Windows.Controls;

namespace UI.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherProfile.xaml
    /// </summary>
    public partial class TeacherProfile : Window
    {

        public TeacherProfile()
        {
            InitializeComponent();

            Title = "Teacher's name goes here";
        }

        //go back
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherInformation());
            this.Visibility = Visibility.Hidden;
        }

        private void Btn_teacherCourseHistory_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
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
