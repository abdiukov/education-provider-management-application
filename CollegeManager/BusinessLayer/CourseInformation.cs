namespace Model
{
    public class CourseInformation
    {
        //CONSTRUCTOR

        /// <param name="CourseID">ID of the course e.g 12</param>
        /// <param name="CourseName">Name of the course e.g Certificate IV in Programming</param>
        /// <param name="LocationID">ID of location where the course will being taught e.g 3</param>
        /// <param name="DeliveryID">ID on how the course will be delivered e.g 1</param>
        /// <param name="StartSemesterID">ID of the semester when the course starts e.g 12</param>
        /// <param name="EndSemesterID">ID of the semester when the course ends e.g 13</param>
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
