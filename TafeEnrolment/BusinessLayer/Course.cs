using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Course
    {
        public string CourseName
        {
            get;set;
        }

        public List<Student> Students
        {
            get;set;
        }

        public List<Teacher> Teachers
        {
            get;set;
        }

    }
}
