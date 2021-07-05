using System.Windows;
using UI.Course;
using UI.Student;
using UI.Teacher;

namespace UI
{
    /// <summary>
    /// Main menu of the application. The first page the user sees after they log in
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialises the page and adds it to the pagesVisitedTracker (which is displayed in navigation bar)
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            App.pagesVisitedTracker.Add(this);
        }

        /// <summary>
        /// When the main menu visibility changes (for example when user navigates back to main menu)
        /// </summary>
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible && App.pagesVisitedTracker.Count != 1)
            {
                PageNavigation.ClearAllPagesExceptMain();
            }
        }

        private void NavigateTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new TeacherInformation(), this);
        }
        private void NavigateCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new CourseInformation(), this);
        }
        private void NavigateStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new StudentInformation(), this);
        }
        private void AddTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new TeacherProfile(), this);
        }
        private void AddCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new CourseProfile(), this);
        }
        private void AddStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new StudentProfile(), this);
        }
        private void AlterTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new Edit.EditTeacher(), this);
        }
        private void AlterStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new Edit.EditStudent(), this);
        }
        private void AlterUnitInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new Edit.EditUnit(), this);
        }
    }
}