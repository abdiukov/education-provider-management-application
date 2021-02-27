using System.Collections.Generic;
using System.Windows;

namespace UI
{
    public partial class MainWindow : Window
    {
        //pagesVisitedTracker is a tracker that contains pages that the user opened.
        public static List<Window> pagesVisitedTracker = new List<Window>();

        //INITIALISATION CODE
        public MainWindow()
        {
            InitializeComponent();
            pagesVisitedTracker.Add(this);
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                PageNavigation.ClearAllPagesExceptMain();
            }
        }
        //END OF INITIALISATION CODE


        //START OF NAVIGATION CODE
        private void NavigateTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new TeacherInformation());
            Hide();
        }

        private void NavigateCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new CourseInformation());
            Hide();
        }

        private void NavigateStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new StudentInformation());
            Hide();
        }
        //END OF NAVIGATION CODE
    }
}