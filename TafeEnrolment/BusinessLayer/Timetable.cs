using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    //student timetable
    public class Timetable
    {
        public string StudentFullName
        {
            get;set;
        }
        
        public List<Course> EnrolledCourses
        {
            get;set;
        }

        public List<Teacher> TeachersForCourse
        {
            get; set;
        }
    }
}
