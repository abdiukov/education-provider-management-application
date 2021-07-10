using System;

namespace BusinessLayer
{
    /// <summary>
    /// Contains information about a teacher who teaches a course or has taught a course in the past.
    /// </summary>
    public class Teacher : Person
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of teacher e.g 20</param>
        /// <param name="Address">Teacher's residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="PersonGender">Teacher's gender e.g Female</param>
        /// <param name="Mobile">Teacher's mobile number e.g 0444-323-131</param>
        /// <param name="Email">Teacher's email e.g MichaelNorton@gmail.com</param>
        /// <param name="DateofBirth">Teacher's date of birth e.g 1993-02-20 (YYYY-MM-DD)</param>
        /// <param name="FirstName">Teacher's first name e.g Michael</param>
        /// <param name="LastName">Teacher's last name e.g Norton</param>
        /// <param name="Position">Teacher's employment position e.g Full Time, Part Time, Online</param>
        /// <param name="IsCurrent">True - The teacher is currently teaching that course. False - The teacher taught that course in the past</param>
        /// <param name="OtherThanBaseLocation">True - the course the teacher teaches is not in their base location(campus). False - the teacher teaches the course at their base campus.</param>
        /// <param name="BaseLocation">ID of teacher's base location (main campus where teacher is employed at) e.g 3</param>
        public Teacher(int Id, string Address, string PersonGender, string Mobile, string Email,
            DateTime DateofBirth, string FirstName, string LastName,
            string Position, bool IsCurrent, bool OtherThanBaseLocation, int BaseLocation)
            : base(Id, Address, PersonGender, Mobile, Email, DateofBirth, FirstName, LastName, Position, IsCurrent)
        {
            this.OtherThanBaseLocation = OtherThanBaseLocation;
            this.BaseLocation = BaseLocation;
        }

        public Teacher(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        //PROPERTIES
        public bool OtherThanBaseLocation { get; set; }
        public int BaseLocation { get; set; }

        //METHODS
        public override string ToString()
        {
            return Id + " | " + FirstName + " | " + LastName;
        }
    }
}
