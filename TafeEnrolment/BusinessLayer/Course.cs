using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Course
    {
        public bool isOffered
        {
            get; set;
        }

        public string CourseName
        {
            get; set;
        }

        public List<Student> Students
        {
            get; set;
        }

        public List<Teacher> Teachers
        {
            get; set;
        }

        public List<Unit> CourseUnits
        {
            get; set;
        }

        public DateTime courseStartDate
        {
            get; set;
        }

        public DateTime courseEndDate
        {
            get; set;
        }

        public string courseStatus
        {
            get; set;
        }

    }
}
