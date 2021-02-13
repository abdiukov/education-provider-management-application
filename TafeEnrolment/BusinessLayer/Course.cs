using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Course
    {
        public string CourseName
        {
            get;set;
        }

        public List<Student> enrolledStudents
        {
            get;set;
        }

        public List<Teacher> currentTeachers
        {
            get;set;
        }

    }
}
