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
        public static string SearchBoxReplaceDefaultValue(string searchboxText)
        {
            return searchboxText == "Enter keywords by which criteria to search" ? "" : searchboxText;
        }

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