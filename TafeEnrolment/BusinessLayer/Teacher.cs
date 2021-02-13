using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Teacher
    {
        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Position
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }

        public List<Course> currentCourses
        {
            get;set;
        }

        public List<PastCourse> pastCourses
        {
            get;set;
        }

    }
}
