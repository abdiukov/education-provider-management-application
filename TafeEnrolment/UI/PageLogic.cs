using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UI
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
        public static List<BusinessLayer.Student> SearchStudent(int searchQuery, bool? searchPartTime, bool? searchFullTime,
            bool? searchNoFees, List<BusinessLayer.Student> Students)
        {
            int v = 0;
            if ((bool)searchPartTime) { v += 4; } //x
            if ((bool)searchFullTime) { v += 2; } //y
            if ((bool)searchNoFees) { v += 1; } //z

            List<BusinessLayer.Student> output = new List<BusinessLayer.Student>();
            switch (v)
            {
                case 0: // all false
                    output = Students;
                    break;
                case 1: // z is true
                    foreach (BusinessLayer.Student item in Students)
                    {
                        if (item.IsFeesNotPaid == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (BusinessLayer.Student item in Students)
                    {
                        if (item.Position == "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 3: // z and y are true
                    foreach (BusinessLayer.Student item in Students)
                    {
                        if (item.Position == "Full Time" && item.IsFeesNotPaid == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 4: // x is true
                    foreach (BusinessLayer.Student item in Students)
                    {
                        if (item.Position != "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 5: //x and z are true
                    foreach (BusinessLayer.Student item in Students)
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
        public static List<BusinessLayer.Teacher> SearchTeacher(int searchQuery, bool? searchPartTime, bool? searchFullTime,
            bool? searchNotBaseLocation, List<BusinessLayer.Teacher> Teachers)
        {
            int v = 0;
            if ((bool)searchPartTime) { v += 4; } //x
            if ((bool)searchFullTime) { v += 2; } //y
            if ((bool)searchNotBaseLocation) { v += 1; } //z

            List<BusinessLayer.Teacher> output = new List<BusinessLayer.Teacher>();


            switch (v)
            {
                case 0: // all false
                    output = Teachers;
                    break;
                case 1: // z is true
                    foreach (BusinessLayer.Teacher item in Teachers)
                    {
                        if (item.OtherThanBaseLocation)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // y is true
                    foreach (BusinessLayer.Teacher item in Teachers)
                    {
                        if (item.Position == "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 3: // z and y are true
                    foreach (BusinessLayer.Teacher item in Teachers)
                    {
                        if (item.Position == "Full Time" && item.OtherThanBaseLocation)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 4: // x is true
                    foreach (BusinessLayer.Teacher item in Teachers)
                    {
                        if (item.Position != "Full Time")
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 5: //x and z are true
                    foreach (BusinessLayer.Teacher item in Teachers)
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
        public static List<BusinessLayer.TeacherCourseHistory> SearchTeacherCourseHistory
            (bool? searchPastCourse, bool? searchPresentCourse, List<BusinessLayer.TeacherCourseHistory> Courses)
        {
            int v = 0;
            if ((bool)searchPastCourse) { v += 2; } //x
            if ((bool)searchPresentCourse) { v += 1; } //y

            List<BusinessLayer.TeacherCourseHistory> output = new List<BusinessLayer.TeacherCourseHistory>();

            switch (v)
            {
                case 1: // y is true
                    foreach (BusinessLayer.TeacherCourseHistory item in Courses)
                    {
                        if (item.IsCurrent == true)
                        {
                            output.Add(item);
                        }
                    }
                    break;
                case 2: // x is true
                    foreach (BusinessLayer.TeacherCourseHistory item in Courses)
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