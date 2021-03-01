using System.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        //INITIALISATION CODE
        public MainWindow()
        {
            InitializeComponent();
            App.pagesVisitedTracker.Add(this);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible && App.pagesVisitedTracker.Count != 1)
            {
                PageNavigation.ClearAllPagesExceptMain();
            }
        }
        //END OF INITIALISATION CODE


        //NAVIGATION CODE
        private void NavigateTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new TeacherInformation());
        }

        private void NavigateCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new CourseInformation());
        }

        private void NavigateStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new StudentInformation());
        }
        //END OF NAVIGATION CODE
    }
}