using System;

namespace BusinessLayer
{
    public class Student
    {

        //CONSTRUCTOR

        public Student(int Id, string Address, string StudentGender, string Mobile, string Email,
            DateTime DateofBirth, string FirstName, string LastName, bool isFeesNotPaid, string Position, bool isCurrent)
        {
            this.Id = Id;
            this.Address = Address;
            this.StudentGender = StudentGender;
            this.Mobile = Mobile;
            this.Email = Email;
            this.DateofBirth = DateofBirth;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.isFeesNotPaid = isFeesNotPaid;
            this.Position = Position;
            this.isCurrent = isCurrent;
            this.isSelected = false;
        }

        public Student(int Id, string FirstName, string LastName, string Address)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.isSelected = false;
        }

        //PROPERTIES

        public string Position
        {
            get; set;
        }

        public int Id
        {
            get; set;
        }
        public string StudentGender
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string Mobile
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public bool isFeesNotPaid
        {
            get; set;
        }

        public bool isCurrent
        {
            get; set;
        }

        public bool isSelected
        {
            get; set;
        }

        public string IsSelectedString
        {
            get { return isSelected ? "Selected" : "Not selected"; }
        }

        //METHODS

        public override string ToString()
        {
            return Id + " | " + FirstName + " " + LastName + " | " + Address;
        }

    }
}
