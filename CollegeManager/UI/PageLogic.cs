using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace View
{
    /// <summary>
    /// Contains search logic
    /// </summary>
    public class PageLogic
    {
        /// <summary>Replaces the default value("Enter ID that you wish to search") with "", otherwise does nothing</summary>
        /// <param name="searchboxText">The text inside the search box e.g Enter ID that you wish to search</param>
        /// <returns>Either the same text, or ""</returns>
        public static string SearchBoxReplaceDefaultValue(string searchboxText)
        {
            return searchboxText == "Enter ID that you wish to search" ? "" : searchboxText;
        }

        /// <param name="searchQuery">The student ID that we search by e.g 10</param>
        /// <param name="searchPartTime">True - the search includes part time students. False - the search excludes part time students</param>
        /// <param name="searchFullTime">True - the search includes full time students. False - the search excludes full time students</param>
        /// <param name="searchNoFees">True - the student has paid all course fees. False - the student has not paid their course fees.</param>
        /// <param name="Students">List of students we are searching from</param>
        /// <returns>List of students that correspond to the search query</returns>
        public static List<Model.Student> SearchStudent(int searchQuery, bool? searchPartTime, bool? searchFullTime,
            bool? searchNoFees, bool? searchCurrent, bool? searchPast, List<Model.Student> Students)
        {
            int v = 0;
            if ((bool)searchPartTime) { v += 4; } //x
            if ((bool)searchFullTime) { v += 2; } //y
            if ((bool)searchNoFees) { v += 1; } //z

            List<Model.Student> output = new List<Model.Student>();
            switch (v)
            {
                case 0: // all false
                    output = Students;
                    break;
                case 1: // z is true
                    foreach (Model.Student item in Students)
                    {
                        if (item.IsFeesNotPaid == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (Model.Student item in Students)
                    {
                        if (item.Position == "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 3: // z and y are true
                    foreach (Model.Student item in Students)
                    {
                        if (item.Position == "Full Time" && item.IsFeesNotPaid == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 4: // x is true
                    foreach (Model.Student item in Students)
                    {
                        if (item.Position != "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 5: //x and z are true
                    foreach (Model.Student item in Students)
                    {
                        if (item.Position != "Full Time" && item.IsFeesNotPaid == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                default: //x and y are true
                    MessageBox.Show("Error! Both part time and Full Time tick boxes are ticked " + searchQuery);
                    output = Students;
                    break;
            }


            int v2 = 0;

            if ((bool)searchCurrent) { v2 += 1; } //x
            if ((bool)searchPast) { v2 += 2; } //y

            switch (v2)
            {
                case 1: // x is true
                    foreach (Model.Student item in output.ToList())
                    {
                        if (item.IsCurrent == false)
                        {
                            output.Remove(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (Model.Student item in output.ToList())
                    {
                        if (item.IsCurrent == true)
                        {
                            output.Remove(item);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (searchQuery != -99999)
            {
                foreach (var item in output.ToList())
                {
                    if (item.Id != searchQuery)
                    {
                        output.Remove(item);
                    }
                }
            }


            return output;
        }

        /// <param name="searchQuery">The teacher ID that we search by e.g 10</param>
        /// <param name="searchPartTime">True - the search includes part time teachers. False - the search excludes part time teachers</param>
        /// <param name="searchFullTime">True - the search includes full time teachers. False - the search excludes full time teachers</param>
        /// <param name="searchNotBaseLocation">True - the teacher is teaching in location other than their base location. False - the teacher is teaching at their base location.</param>
        /// <param name="Teachers">List of teachers we are searching from</param>
        /// <returns>List of teachers that correspond to the search query</returns>
        public static List<Model.Teacher> SearchTeacher(int searchQuery, bool? searchPartTime, bool? searchFullTime,
            bool? searchNotBaseLocation, bool? searchCurrent, bool? searchPast, List<Model.Teacher> Teachers)
        {
            int v = 0;
            if ((bool)searchPartTime) { v += 4; } //x
            if ((bool)searchFullTime) { v += 2; } //y
            if ((bool)searchNotBaseLocation) { v += 1; } //z

            List<Model.Teacher> output = new List<Model.Teacher>();


            switch (v)
            {
                case 0: // all false
                    output = Teachers;
                    break;
                case 1: // z is true
                    foreach (Model.Teacher item in Teachers)
                    {
                        if (item.OtherThanBaseLocation)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (Model.Teacher item in Teachers)
                    {
                        if (item.Position == "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 3: // z and y are true
                    foreach (Model.Teacher item in Teachers)
                    {
                        if (item.Position == "Full Time" && item.OtherThanBaseLocation)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 4: // x is true
                    foreach (Model.Teacher item in Teachers)
                    {
                        if (item.Position != "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 5: //x and z are true
                    foreach (Model.Teacher item in Teachers)
                    {
                        if (item.Position != "Full Time" && item.OtherThanBaseLocation)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                default: //x and y are true
                    MessageBox.Show("Error! Both part time and Full Time tick boxes are ticked " + searchQuery);
                    output = Teachers;
                    break;
            }

            int v2 = 0;

            if ((bool)searchCurrent) { v2 += 1; } //x
            if ((bool)searchPast) { v2 += 2; } //y

            switch (v2)
            {
                case 1: // x is true
                    foreach (Model.Teacher item in output.ToList())
                    {
                        if (item.IsCurrent == false)
                        {
                            output.Remove(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (Model.Teacher item in output.ToList())
                    {
                        if (item.IsCurrent == true)
                        {
                            output.Remove(item);
                        }
                    }
                    break;
                default:
                    break;
            }


            if (searchQuery != -99999)
            {
                foreach (var item in output.ToList())
                {
                    if (item.Id != searchQuery)
                    {
                        output.Remove(item);
                    }
                }
            }

            return output;
        }



        /// <param name="searchPastCourse">True - the search includes past courses. False - the search excludes past course</param>
        /// <param name="searchPresentCourse">True - the search includes present courses. False - the search excludes present course</param>
        /// <param name="Courses">List of courses we are searching from</param>
        /// <returns>List of courses that correspond to the search query</returns>
        public static List<Model.TeacherCourseHistory> SearchTeacherCourseHistory
            (bool? searchPastCourse, bool? searchPresentCourse, List<Model.TeacherCourseHistory> Courses)
        {
            int v = 0;
            if ((bool)searchPastCourse) { v += 2; } //x
            if ((bool)searchPresentCourse) { v += 1; } //y

            List<Model.TeacherCourseHistory> output = new List<Model.TeacherCourseHistory>();

            switch (v)
            {
                case 1: // y is true
                    foreach (Model.TeacherCourseHistory item in Courses)
                    {
                        if (item.IsCurrent == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // x is true
                    foreach (Model.TeacherCourseHistory item in Courses)
                    {
                        if (item.IsCurrent == false)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                default:
                    output = Courses;
                    break;
            }
            return output;

        }

    }
}