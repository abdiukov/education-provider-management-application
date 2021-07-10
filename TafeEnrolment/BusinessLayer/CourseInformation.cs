namespace Model
{
    public class CourseInformation
    {
        //CONSTRUCTOR
        public CourseInformation(int CourseID, string CourseName, int LocationID, int DeliveryID, int StartSemesterID, int EndSemesterID)
        {
            this.CourseID = CourseID;
            this.CourseName = CourseName;
            this.LocationID = LocationID;
            this.DeliveryID = DeliveryID;
            this.StartSemesterID = StartSemesterID;
            this.EndSemesterID = EndSemesterID;
        }

        //PROPERTIES
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int LocationID { get; set; }
        public int DeliveryID { get; set; }
        public int StartSemesterID { get; set; }
        public int EndSemesterID { get; set; }

        //METHODS
        public override string ToString()
        {
            return CourseID + " | " + CourseName;
        }
    }
}
