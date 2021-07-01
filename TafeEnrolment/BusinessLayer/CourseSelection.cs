namespace BusinessLayer
{
    /// <summary>
    /// Class contains general information about courses
    /// </summary>
    public class CourseSelection : Course
    {
        //CONSTRUCTOR


        /// <param name="CourseName">Name of the course e.g Certificate IV in Programming</param>
        /// <param name="CampusName">Name of the campus e.g Granville</param>
        /// <param name="Delivery">How the course is delivered e.g Full Time</param>
        public CourseSelection(int CourseID, string CourseName, string Delivery, string CampusName)
            : base(CourseName, Delivery, CampusName)
        {
            this.CourseID = CourseID;
        }

        //PROPERTIES
        public int CourseID
        {
            get; set;
        }

        //METHODS
        public override string ToString()
        {
            return CourseName + " - " + CampusName + " - " + Delivery;
        }


    }
}
