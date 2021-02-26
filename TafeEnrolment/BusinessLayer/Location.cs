using System.Collections.Generic;

namespace BusinessLayer
{
    public class Location
    {
        public string LocationName
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

    }
}
