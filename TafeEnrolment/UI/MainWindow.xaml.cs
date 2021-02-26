using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //declaring a tracker that has all the pages
        //the page visited tracker can only hold 10 pages, however as the program size increases, this number should be changed
        public static List <Window> pagesVisitedTracker = new List<Window>();

        public MainWindow()
        {
            InitializeComponent();
            pagesVisitedTracker.Append(this);
        }


        //Navigation
        private void NavigateTeacherInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new TeacherInformation());
            Close();
        }

        private void NavigateCourseInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new CourseInformation());
            Close();
        }

        private void NavigateStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.GoToNewPage(new StudentInformation());
            Close();
        }

    }
}
