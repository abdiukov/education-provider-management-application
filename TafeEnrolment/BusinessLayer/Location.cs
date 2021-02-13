using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    class Location
    {
        public string LocationName
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
