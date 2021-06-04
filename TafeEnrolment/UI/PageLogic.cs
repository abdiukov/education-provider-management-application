using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UI
{
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
                        if (item.isFeesNotPaid == true)
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
                        if (item.Position == "Full Time" && item.isFeesNotPaid == true)
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
                        if (item.Position != "Full Time" && item.isFeesNotPaid == true)
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

        public static void SearchTeacher(string searchQuery, bool? searchPartTime, bool? searchFullTime, bool? searchNotBaseLocation)
        {
            searchQuery = SearchBoxReplaceDefaultValue(searchQuery);
            int v = 0;
            if ((bool)searchPartTime) { v += 4; } //x
            if ((bool)searchFullTime) { v += 2; } //y
            if ((bool)searchNotBaseLocation) { v += 1; } //z

            switch (v)
            {
                case 0: // all false
                    MessageBox.Show("Search everyone " + searchQuery);
                    break;
                case 1: // z is true
                    MessageBox.Show("Show teachers who are not teaching at their base location " + searchQuery);
                    break;
                case 2: // y is true
                    MessageBox.Show("Search Full Time " + searchQuery);
                    break;
                case 3: // z and y are true
                    MessageBox.Show("Search Full Time and not teaching at their base location " + searchQuery);
                    break;
                case 4: // x is true
                    MessageBox.Show("Search part time " + searchQuery);
                    break;
                case 5: //x and z are true
                    MessageBox.Show("Search part time and not teaching at their base location " + searchQuery);
                    break;
                default: //x and y are true
                    MessageBox.Show("Error! Both part time and Full Time tick boxes are ticked " + searchQuery);
                    break;
            }
        }

        public static void SearchCourseTimetable(string searchQuery)
        {
            searchQuery = SearchBoxReplaceDefaultValue(searchQuery);

            MessageBox.Show(searchQuery);
        }

        public static void SearchTeacherCourseHistory(string searchQuery, bool? searchPastCourse, bool? searchPresentCourse)
        {
            searchQuery = SearchBoxReplaceDefaultValue(searchQuery);

            int v = 0;
            if ((bool)searchPastCourse) { v += 2; } //x
            if ((bool)searchPresentCourse) { v += 1; } //y

            switch (v)
            {

                case 0: //either both x and y are true or none are true
                case 3:
                    MessageBox.Show("Search everyone " + searchQuery);
                    break;
                case 1: // y is true
                    MessageBox.Show("Show past courses" + searchQuery);
                    break;
                case 2: // x is true
                    MessageBox.Show("Search current courses " + searchQuery);
                    break;
            }

        }


    }
}