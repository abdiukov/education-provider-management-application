namespace BusinessLayer
{
    /// <summary>
    /// Contains infromation about student enrolment, such as payment details, course details, student details.
    /// </summary>
    public class Enrolment
    {
        //CONSTRUCTOR

        /// <param name="FirstName">First name of the student who has been enrolled e.g John</param>
        /// <param name="LastName">Last name of the student who has been enrolled e.g Denver</param>
        /// <param name="CourseName">The name of the course e.g Diploma in Software Development</param>
        /// <param name="AmountPaid">How much the student has already paid e.g $3000</param>
        /// <param name="AmountDue">How much the student needs to pay for the course cost(not including the money already been paid) e.g $7000</param>
        /// <param name="CourseLocation">Where the course is being delivered e.g Granville</param>
        /// <param name="CourseAddress">The street address on where the course is being delivered</param>
        /// <param name="IsCurrent">Boolean true or false value, whether the course is being delivered RIGHT NOW</param>
        /// <param name="CourseStudentID">The unique ID that links the student to the course and to the course result e.g 20</param>
        public Enrolment(string FirstName, string LastName, string CourseName, double AmountPaid,
            double AmountDue, string CourseLocation, string CourseAddress, bool IsCurrent, int CourseStudentID)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.CourseName = CourseName;
            this.AmountPaid = AmountPaid;
            this.AmountDue = AmountDue;
            this.CourseLocation = CourseLocation;
            this.CourseAddress = CourseAddress;
            this.IsCurrent = IsCurrent;
            this.CourseStudentID = CourseStudentID;
        }

        //PROPERTIES
        public bool IsCurrent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public double AmountPaid { get; set; }
        public double AmountDue { get; set; }
        public string CourseLocation { get; set; }
        public string CourseAddress { get; set; }
        public int CourseStudentID { get; set; }
    }
}
