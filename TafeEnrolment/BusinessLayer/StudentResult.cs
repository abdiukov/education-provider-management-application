namespace BusinessLayer
{
    public class StudentResult
    {
        public StudentResult(int studentID, string courseName, string courseLocation, string outcome)
        {
            StudentID = studentID;
            CourseName = courseName;
            CourseLocation = courseLocation;
            Outcome = outcome;
        }

        public int StudentID
        {
            get; set;
        }

        public string CourseName
        {
            get; set;
        }

        public string CourseLocation
        {
            get; set;
        }
        public string Outcome
        {
            get; set;
        }
    }
}
