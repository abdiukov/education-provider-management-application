using ModelLayer;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class TeacherCourseHistory : Window
    {
        Logic logic = new Logic();
        List<BusinessLayer.Course> Courses = new List<BusinessLayer.Course>();
        List<BusinessLayer.Course> CoursesCopy = new List<BusinessLayer.Course>();

        //INITIALISATION CODE
        public TeacherCourseHistory(int teacherID)
        {
            InitializeComponent();
            this.Title = "Course history for ID " + teacherID;
            Courses = (List<BusinessLayer.Course>)logic.GetTeacherHistoryByID(teacherID);
            dgCourseHistory.ItemsSource = Courses;
            CoursesCopy = Courses;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                dgNavigationBar.ItemsSource = null;
                dgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE


        //NAVIGATION CODE

        private void dgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(dgNavigationBar.SelectedIndex);
        }

        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new TeacherInformation());
        }

        //END OF NAVIGATION CODE

        //SEARCH DATAGRID CODE


        private void Search()
        {

            List<BusinessLayer.Course> SearchResult = PageLogic.SearchTeacherCourseHistory(checkbox_SearchPastCourse.IsChecked,
                checkbox_SearchPresentCourse.IsChecked, Courses);

            dgCourseHistory.ItemsSource = SearchResult;
            Courses = CoursesCopy;
        }


        private void checkbox_SearchPastCourse_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPresentCourse.IsChecked = false;
            Search();
        }

        private void checkbox_SearchPresentCourse_Checked(object sender, RoutedEventArgs e)
        {
            checkbox_SearchPastCourse.IsChecked = false;
            Search();
        }

        private void checkbox_SearchPresentCourse_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void checkbox_SearchPastCourse_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }


        //END OF SEARCH DATAGRID CODE

        //DATAGRID SETTINGS CODE

        private void dgCourseHistory_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(dgCourseHistory);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE

    }
}
