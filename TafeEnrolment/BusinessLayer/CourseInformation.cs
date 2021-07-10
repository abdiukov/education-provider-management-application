namespace Model
{
    public class CourseInformation
    {
        public CourseInformation(string CourseName, int LocationID, int DeliveryID, int StartSemesterID, int EndSemesterID)
        {
            this.CourseName = CourseName;
            this.LocationID = LocationID;
            this.DeliveryID = DeliveryID;
            this.StartSemesterID = StartSemesterID;
            this.EndSemesterID = EndSemesterID;
        }


        //PROPERTIES
        public string CourseName { get; set; }
        public int LocationID { get; set; }
        public int DeliveryID { get; set; }
        public int StartSemesterID { get; set; }
        public int EndSemesterID { get; set; }


        //METHODS
        public override string ToString()
        {
            return CourseName;
        }
    }
}
