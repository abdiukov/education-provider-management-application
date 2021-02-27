using System.Windows;
using System.Windows.Controls;

namespace UI.Teacher
{
    public partial class TeacherProfile : Window
    {
        //INITIALISATION CODE
        public TeacherProfile()
        {
            InitializeComponent();
            Title = "Teacher's name goes here";
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
        private void dgBreadcrmbs_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgBreadcrmbs.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgBreadcrmbs.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new TeacherInformation());
        }

        private void Btn_teacherCourseHistory_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewOrExistingPage(new TeacherCourseHistory());
        }

        //END OF NAVIGATION CODE
    }
}
