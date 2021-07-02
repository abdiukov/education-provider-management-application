using System;

namespace BusinessLayer
{
    /// <summary>
    /// Contains information about all the courses and course statistics
    /// </summary>
    public class Timetable : Course
    {
        //CONSTRUCTOR

        /// <param name="CourseID">ID of the course e.g 12</param>
        /// <param name="CourseName">Name of the course e.g Certificate IV in Programming</param>
        /// <param name="StartDate">The date when the the course commences 2020-05-05 (YYYY-MM-DD)</param>
        /// <param name="EndDate">The date when the the course ends 2020-09-05 (YYYY-MM-DD) </param>
        /// <param name="CampusName">Name of the campus where the course is being delivered e.g Granville</param>
        /// <param name="ContactNumber">The phone number that can be used to contact the campus e.g 0400-123-456</param>
        /// <param name="Delivery">How the course is delivered e.g Full Time</param>
        /// <param name="AmountOfUnits">How many units the course contains e.g 22</param>
        /// <param name="AmountOfTeachers">How many teachers are teaching that class of students e.g 2 </param>
        /// <param name="AmountOfStudents">How many students are enrolled into that class e.g 12</param>
        /// <param name="IsCurrent">Boolean true or false value on whether the course being taught right now </param>
        public Timetable(int CourseID, string CourseName, DateTime StartDate, DateTime EndDate, string CampusName, string ContactNumber,
            string Delivery, int AmountOfUnits, int AmountOfTeachers, int AmountOfStudents, bool IsCurrent)
            : base(CourseName, Delivery, CampusName)
        {
            this.CourseID = CourseID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ContactNumber = ContactNumber;
            this.AmountOfUnits = AmountOfUnits;
            this.AmountOfTeachers = AmountOfTeachers;
            this.AmountOfStudents = AmountOfStudents;
            this.IsCurrent = IsCurrent;
        }
        //PROPERTIES

        public int CourseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ContactNumber { get; set; }
        public int AmountOfUnits { get; set; }
        public int AmountOfTeachers { get; set; }
        public int AmountOfStudents { get; set; }
        public bool IsCurrent { get; set; }
    }
}
