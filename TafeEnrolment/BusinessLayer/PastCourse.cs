using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class PastCourse
    {
        public string CourseName
        {
            get; set;
        }

        public List<Student> enrolledStudents
        {
            get; set;
        }

        public List<Teacher> currentTeachers
        {
            get; set;
        }
    }
}
