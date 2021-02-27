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
            if (pagesVisitedTracker.Count != 1 && Visibility == Visibility.Visible)
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