using System.Windows;
using UI.Course;
using UI.Student;
using UI.Teacher;

namespace UI
{
    public partial class MainWindow : Window
    {
        //INITIALISATION CODE
        public MainWindow()
        {
            InitializeComponent();
            if (App.pagesVisitedTracker.Count == 0)
            {
                App.pagesVisitedTracker.Add(this);
            }
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

        private void AddTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new TeacherProfile());
        }

        private void AddCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new CourseProfile());
        }

        private void AddStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToNewPage(new StudentProfile());

        }

        private void AlterTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            //PageNavigation.GoToNewPage(new StudentProfile());
        }

        private void AlterStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            //PageNavigation.GoToNewPage(new StudentProfile());
        }

        private void AlterUnitInfo_Click(object sender, RoutedEventArgs e)
        {
            //Hide();
            //PageNavigation.GoToNewPage(new StudentProfile());
        }

        //END OF NAVIGATION CODE

    }
}