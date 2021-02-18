using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    
    public class Timetable
    {   
        public List<Course> EnrolledCourses
        {
            get;set;
        }

        public List<Teacher> TeachersForCourse
        {
            get; set;
        }

        public List<Location> location
        {
            get;set;
        }

        public DateTime startDate
        {
            get;set;
        }

        public DateTime endDate
        {
            get;set;
        }
    }
}
