namespace BusinessLayer
{
    /// <summary>
    /// Contains in-depth infromation about a real course that is either currently being offered or has been offered in the past. 
    /// </summary>
    public class CourseSelection : Course
    {
        //CONSTRUCTOR

        /// <param name="CourseID">ID of the course e.g 12</param>
        /// <param name="CourseName">Name of the course e.g Certificate IV in Programming</param>
        /// <param name="CampusName">Name of the campus e.g Granville</param>
        /// <param name="Delivery">How the course is delivered e.g Full Time</param>
        public CourseSelection(int CourseID, string CourseName, string Delivery, string CampusName)
            : base(CourseName, Delivery, CampusName)
        {
            this.CourseID = CourseID;
        }

        //PROPERTIES
        public int CourseID { get; set; }

        //METHODS
        public override string ToString()
        {
            return CourseName + " - " + CampusName + " - " + Delivery;
        }

    }
}
