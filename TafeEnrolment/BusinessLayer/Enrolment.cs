namespace BusinessLayer
{
    public class Enrolment
    {
        public Enrolment(string firstName, string lastName, string courseName, double amountPaid,
            double amountDue, string courseLocation, string courseAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            CourseName = courseName;
            AmountPaid = amountPaid;
            AmountDue = amountDue;
            CourseLocation = courseLocation;
            CourseAddress = courseAddress;
        }

        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string CourseName
        {
            get; set;
        }
        public double AmountPaid
        {
            get; set;
        }
        public double AmountDue
        {
            get; set;
        }
        public string CourseLocation
        {
            get; set;
        }
        public string CourseAddress
        {
            get; set;
        }
    }
}
