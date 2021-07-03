namespace BusinessLayer
{
    /// <summary>
    /// Abstract class that is inherited by CourseSelection.cs and TeacherCourseHistory.cs.
    /// Abstract class contains general information about courses
    /// </summary>
    public abstract class Course
    {
        //CONSTRUCTOR
        public Course(string CourseName, string Delivery, string CampusName)
        {
            this.CourseName = CourseName;
            this.CampusName = CampusName;
            this.Delivery = Delivery;
        }

        //PROPERTIES
        public string CourseName { get; set; }
        public string CampusName { get; set; }
        public string Delivery { get; set; }

    }
}
