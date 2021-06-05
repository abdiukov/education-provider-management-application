namespace BusinessLayer
{
    public class NotOfferedCourse
    {

        //CONSTRUCTOR
        public NotOfferedCourse(int CourseID, string CourseName, string Delivery, string CampusName)
        {
            this.CourseName = CourseName;
            this.CampusName = CampusName;
            this.Delivery = Delivery;
            this.CourseID = CourseID;
        }

        //PROPERTIES
        public int CourseID
        {
            get; set;
        }

        public string CourseName
        {
            get; set;
        }

        public string CampusName
        {
            get; set;
        }

        public string Delivery
        {
            get; set;
        }


    }
}
