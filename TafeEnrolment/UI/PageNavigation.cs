using UI.Student;
using UI.Teacher;

namespace UI
{
    class PageNavigation
    {
        public static void Navigate(string PageToNavigateTo)
        {
            //listing all the pages that the user can be navigated to
            switch (PageToNavigateTo)
            {
                case "MainWindow":
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
