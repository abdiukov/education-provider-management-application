using System.Linq;
using System.Windows;

namespace UI
{
    /// <summary>
    /// This method responsible for navigation throughout pages
    /// If the page is not hidden a new  page is created and the user is navigated to it.
    /// If the page is hidden, the page gets unhidden and the user navigates to it
    /// </summary>
    class PageNavigation
    {

        public static void GoToNewPage(Window pageToNavigate)
        {
            MainWindow.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
        }

        public static void GoToExistingPage(int indexOfPage)
        {
            MainWindow.pagesVisitedTracker[indexOfPage].Show();
        }

        public static void GoToNewOrExistingPage(Window pageToNavigate)
        {

            if (MainWindow.pagesVisitedTracker.Contains(pageToNavigate))
            {
                pageToNavigate.Show();
            }
            else
            {
                GoToNewPage(pageToNavigate);
            }
        }







        //    public static void Navigate(string PageToNavigateTo)
        //    {

        //        foreach (Window window in App.Current.Windows)
        //        {
        //            //if the window is hidden and is the window that I am looking for SHOW IT and go back
        //            //window.ToString().Substring(window.ToString().LastIndexOf('.') + 1)  = turns the window name from "UI.Teacher.TeacherProfile" into "TeacherProfile" 
        //            if (window.Visibility == Visibility.Hidden &&
        //                 window.ToString().Substring(window.ToString().LastIndexOf('.') + 1) == PageToNavigateTo)
        //            {
        //                window.Show();
        //                return;
        //            }
        //        }

        //        //listing all the pages that the user can be navigated to
        //        switch (PageToNavigateTo)
        //        {
        //            case "MainWindow":
        //                //Closes all the hidden tabs
        //                ClosePage("AllHidden");

        //                MainWindow mainwindow_page = new  MainWindow();
        //                mainwindow_page.Show();
        //                break;
        //            case "TeacherInformation":
        //                TeacherInformation teacherinformation_page = new  TeacherInformation();
        //                teacherinformation_page.Show();
        //                break;
        //            case "StudentInformation":
        //                StudentInformation studentinformation_page = new  StudentInformation();
        //                studentinformation_page.Show();
        //                break;
        //            case "CourseInformation":
        //                CourseInformation courseinformation_page = new  CourseInformation();
        //                courseinformation_page.Show();
        //                break;
        //            case "TeacherProfile":
        //                TeacherProfile teacherprofile_page = new  TeacherProfile();
        //                teacherprofile_page.Show();
        //                break;
        //            case "TeacherCourseHistory":
        //                TeacherCourseHistory teachercoursehistory_page = new  TeacherCourseHistory();
        //                teachercoursehistory_page.Show();
        //                break;
        //            case "StudentEnrolment":
        //                StudentEnrolment studentenrolment_page = new  StudentEnrolment();
        //                studentenrolment_page.Show();
        //                break;
        //            case "StudentProfile":
        //                StudentProfile studentprofile_page = new  StudentProfile();
        //                studentprofile_page.Show();
        //                break;
        //            case "StudentResultSearch":
        //                StudentResultSearch studentresultsearch_page = new  StudentResultSearch();
        //                studentresultsearch_page.Show();
        //                break;
        //            case "CourseNotOffered":
        //                CourseNotOffered coursenotoffered_page = new  CourseNotOffered();
        //                coursenotoffered_page.Show();
        //                break;
        //            case "CourseTimetableSearch":
        //                CourseTimetableSearch coursetimetablesearch_page = new  CourseTimetableSearch();
        //                coursetimetablesearch_page.Show();
        //                break;
        //            case "SubjectsClustered":
        //                SubjectsClustered subjectsclustered_page = new  SubjectsClustered();
        //                subjectsclustered_page.Show();
        //                break;
        //            case "SubjectsWithNoCourse":
        //                SubjectsWithNoCourse subjectswithnocourse_page = new  SubjectsWithNoCourse();
        //                subjectswithnocourse_page.Show();
        //                break;
        //        }
        //    }

        //    /// <summary>
        //    /// Closes a specific page,
        //    /// Or alternatively, if user requested "AllHidden", closes all the hidden pages
        //    /// HOWEVER THIS METHOD DOES NOT REMOVE PAGES FROM XML DATABASE, IT ONLY DOES IT IN THE UI
        //    /// </summary>
        //    /// <param name="PageToClose">The page that the user wishes to close</param>
        //    public static void ClosePage(string PageToClose)
        //    {
        //        switch (PageToClose)
        //        {
        //            case "AllHidden":
        //                foreach (Window window in App.Current.Windows)
        //                {
        //                    if (window.Visibility == Visibility.Hidden)
        //                    {
        //                        window.Close();
        //                    }
        //                }
        //                break;

        //            default:
        //                foreach (Window window in App.Current.Windows)
        //                {
        //                    if (window.ToString().Substring(window.ToString().LastIndexOf('.') + 1) == PageToClose)
        //                    {
        //                        window.Close();
        //                        return;
        //                    }
        //                }
        //                break;
        //        }

        //    }
        //}
    }
}
