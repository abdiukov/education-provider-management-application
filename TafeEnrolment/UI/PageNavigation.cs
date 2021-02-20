using BusinessLayer;
using System.Windows;
using UI.Student;
using UI.Teacher;

namespace UI
{
    class PageNavigation
    {
        public static void Navigate(string PageToNavigateTo)
        {

            foreach (Window window in App.Current.Windows)
            {
                //if the window is hidden and is the window that I am looking for SHOW IT and go back
                //window.ToString().Substring(window.ToString().LastIndexOf('.') + 1)  = turns the window name from "UI.Teacher.TeacherProfile" into "TeacherProfile" 
                if (!window.IsActive &&
                     window.ToString().Substring(window.ToString().LastIndexOf('.') + 1) == PageToNavigateTo)
                {
                    Breadcrumbs.RemoveItem(PageToNavigateTo);
                    window.Show();
                    return;
                }
            }

            //listing all the pages that the user can be navigated to
            switch (PageToNavigateTo)
            {
                case "MainWindow":
                    //Closes all the hidden tabs
                    foreach (Window window in App.Current.Windows)
                    {
                        if (!window.IsActive)
                        {
                            window.Close();
                        }
                    }
                    MainWindow mainwindow_page = new MainWindow();
                    mainwindow_page.Show();

                    break;
                case "TeacherInformation":
                    TeacherInformation teacherinformation_page = new TeacherInformation();
                    teacherinformation_page.Show();
                    break;
                case "StudentInformation":
                    StudentInformation studentinformation_page = new StudentInformation();
                    studentinformation_page.Show();
                    break;
                case "CourseInformation":
                    CourseInformation courseinformation_page = new CourseInformation();
                    courseinformation_page.Show();
                    break;
                case "TeacherProfile":
                    TeacherProfile teacherprofile_page = new TeacherProfile();
                    teacherprofile_page.Show();
                    break;
                case "TeacherCourseHistory":
                    TeacherCourseHistory teachercoursehistory_page = new TeacherCourseHistory();
                    teachercoursehistory_page.Show();
                    break;
                case "StudentEnrolment":
                    StudentEnrolment studentenrolment_page = new StudentEnrolment();
                    studentenrolment_page.Show();
                    break;
                case "StudentProfile":
                    StudentProfile studentprofile_page = new StudentProfile();
                    studentprofile_page.Show();
                    break;
                case "StudentResultSearch":
                    StudentResultSearch studentresultsearch_page = new StudentResultSearch();
                    studentresultsearch_page.Show();
                    break;
                case "CourseNotOffered":
                    CourseNotOffered coursenotoffered_page = new CourseNotOffered();
                    coursenotoffered_page.Show();
                    break;
                case "CourseTimetableSearch":
                    CourseTimetableSearch coursetimetablesearch_page = new CourseTimetableSearch();
                    coursetimetablesearch_page.Show();
                    break;
                case "SubjectsClustered":
                    SubjectsClustered subjectsclustered_page = new SubjectsClustered();
                    subjectsclustered_page.Show();
                    break;
                case "SubjectsWithNoCourse":
                    SubjectsWithNoCourse subjectswithnocourse_page = new SubjectsWithNoCourse();
                    subjectswithnocourse_page.Show();
                    break;
            }
        }
    }
}
