using System.Collections.Generic;

namespace BusinessLayer
{
    public class Teacher
    {
        public bool OtherThanBaseLocation
        {
            get; set;
        }

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
            get; set;
        }

        public List<PastCourse> pastCourses
        {
            get; set;
        }

    }
}
