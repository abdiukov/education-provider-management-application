namespace Model
{
    /// <summary>
    /// Contains infromation about a real course that is either being offered or has been offered in the past. 
    /// </summary>
    public class TeacherCourseHistory : Course
    {
        //CONSTRUCTOR

        /// <param name="CourseName">Name of the course e.g Certificate IV in Programming</param>
        /// <param name="Semester">Name of the semester e.g Semester 2 2018</param>
        /// <param name="CampusName">Name of the campus e.g Granville</param>
        /// <param name="Delivery">How the course is delivered e.g Full Time</param>
        /// <param name="IsCurrent">Boolean - whether the course is currently being offered</param>
        public TeacherCourseHistory(string CourseName, string Semester, string CampusName, string Delivery, bool IsCurrent)
            : base(CourseName, Delivery, CampusName)
        {
            this.IsCurrent = IsCurrent;
            this.Semester = Semester;
        }

        //PROPERTIES
        public bool IsCurrent { get; set; }
        public string Semester { get; set; }
    }
}
