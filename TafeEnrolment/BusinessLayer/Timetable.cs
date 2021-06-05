using System;

namespace BusinessLayer
{

    public class Timetable
    {
        //CONSTRUCTOR

        public Timetable(int CourseID, string courseName, DateTime startDate, DateTime endDate, string location, string ContactNumber,
            string delivery, int amountOfUnits, int amountOfTeachers, int amountOfStudents, bool IsCurrent)
        {
            this.CourseID = CourseID;
            CourseName = courseName;
            this.startDate = startDate;
            this.endDate = endDate;
            Location = location;
            Delivery = delivery;
            this.ContactNumber = ContactNumber;
            AmountOfUnits = amountOfUnits;
            AmountOfTeachers = amountOfTeachers;
            AmountOfStudents = amountOfStudents;
            this.IsCurrent = IsCurrent;
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

        public DateTime startDate
        {
            get; set;
        }

        public DateTime endDate
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }

        public string ContactNumber
        {
            get; set;
        }


        public string Delivery
        {
            get; set;
        }

        public int AmountOfUnits
        {
            get; set;
        }

        public int AmountOfTeachers
        {
            get; set;
        }

        public int AmountOfStudents
        {
            get; set;
        }

        public bool IsCurrent
        {
            get; set;
        }

    }
}
