using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI
{
    public partial class TeacherCourseHistory : Window
    {

        List<BusinessLayer.TeacherCourseHistory> Courses = new List<BusinessLayer.TeacherCourseHistory>();
        readonly List<BusinessLayer.TeacherCourseHistory> CoursesCopy = new List<BusinessLayer.TeacherCourseHistory>();

        //INITIALISATION CODE
        public TeacherCourseHistory(int teacherID)
        {
            InitializeComponent();
            this.Title = "Course history for ID " + teacherID;
            Courses = (List<BusinessLayer.TeacherCourseHistory>)App.logic.GetFromDB("GetTeacherHistoryByID", new object[] { teacherID });
            DgCourseHistory.ItemsSource = Courses;
            CoursesCopy = Courses;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DgNavigationBar.ItemsSource = null;
                DgNavigationBar.ItemsSource = App.pagesVisitedTracker;
            }
        }

        //END OF INITIALISATION CODE


        //NAVIGATION CODE

        private void DgNavigationBar_NavigateToSelectedPage(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            DgNavigationBar.CancelEdit();
            Hide();
            PageNavigation.GoToExistingPage(DgNavigationBar.SelectedIndex);
        }

        private void GoBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            PageNavigation.GoToExistingPage(new TeacherInformation());
        }

        //END OF NAVIGATION CODE

        //SEARCH DATAGRID CODE


        private void Search()
        {

            List<BusinessLayer.TeacherCourseHistory> SearchResult = PageLogic.SearchTeacherCourseHistory(Checkbox_SearchPastCourse.IsChecked,
                Checkbox_SearchPresentCourse.IsChecked, Courses);

            DgCourseHistory.ItemsSource = SearchResult;
            Courses = CoursesCopy;
        }


        private void Checkbox_SearchPastCourse_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchPresentCourse.IsChecked = false;
            Search();
        }

        private void Checkbox_SearchPresentCourse_Checked(object sender, RoutedEventArgs e)
        {
            Checkbox_SearchPastCourse.IsChecked = false;
            Search();
        }

        private void Checkbox_SearchPresentCourse_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Checkbox_SearchPastCourse_Unchecked(object sender, RoutedEventArgs e)
        {
            Search();
        }


        //END OF SEARCH DATAGRID CODE

        //DATAGRID SETTINGS CODE

        private void DgCourseHistory_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            //code for changing the datagrid settings
            DataGridSettings page = new DataGridSettings(DgCourseHistory);
            page.Show();
        }

        //END OF DATAGRID SETTINGS CODE

    }
}
