using System;

namespace BusinessLayer
{
    /// <summary>
    /// Contains information about a student who attends a college or has attended the college in the past.
    /// </summary>
    public class Student : Person
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of student e.g 10</param>
        /// <param name="Address">Student's residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="PersonGender">Student's gender e.g Male</param>
        /// <param name="Mobile">Student's mobile number e.g 0444-123-431</param>
        /// <param name="Email">Student's email e.g HowardSmith@gmail.com</param>
        /// <param name="DateofBirth">Student's date of birth e.g 2003-11-15 (YYYY-MM-DD)</param>
        /// <param name="FirstName">Student's first name e.g Howard</param>
        /// <param name="LastName">Student's last name e.g Smith</param>
        /// <param name="IsFeesNotPaid">Boolean true or false value on whether the student has paid all the course fees</param>
        /// <param name="Position">How the student attends/attended the course e.g Full Time, Part Time, Online</param>
        /// <param name="IsCurrent">True - The student is currently attending/ will attend in the future. False - The student attended in the past</param>
        public Student(int Id, string Address, string PersonGender, string Mobile, string Email,
            DateTime DateofBirth, string FirstName, string LastName, bool IsFeesNotPaid, string Position, bool IsCurrent)
            : base(Id, Address, PersonGender, Mobile, Email, DateofBirth, FirstName, LastName, Position, IsCurrent)
        {
            this.IsSelected = false;
            this.IsFeesNotPaid = IsFeesNotPaid;
        }

        /// <param name="Id">ID of student e.g 10</param>
        /// <param name="FirstName">Student's first name e.g Howard</param>
        /// <param name="LastName">Student's last name e.g Smith</param>
        /// <param name="Address">Student's residential address e.g 22 Column Street, Blacktown 2133</param>
        public Student(int Id, string FirstName, string LastName, string Address) : base(Id, FirstName, LastName, Address)
        {
            this.IsSelected = false;
        }

        //PROPERTIES
        public bool IsFeesNotPaid { get; set; }

        //METHODS
        public override string ToString()
        {
            return Id + " | " + FirstName + " " + LastName + " | " + Address;
        }

    }
}
