using System;

namespace BusinessLayer
{
    public class Teacher
    {

        //CONSTRUCTOR
        public Teacher(int id, string address, string teacherGender, string mobile, string email,
            DateTime dateofBirth, string FirstName, string LastName, string Position, bool isCurrent, bool OtherThanBaseLocation)
        {
            Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Address = address;
            Mobile = mobile;
            Email = email;
            TeacherGender = teacherGender;
            DateofBirth = dateofBirth;
            this.Position = Position;
            this.isCurrent = isCurrent;
            this.OtherThanBaseLocation = OtherThanBaseLocation;
        }

        //PROPERTIES

        public string Position
        {
            get; set;
        }

        public bool isCurrent
        {
            get; set;
        }
        public bool OtherThanBaseLocation
        {
            get; set;
        }

        public int Id
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
        public string Email
        {
            get; set;
        }

        public string TeacherGender
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public string Mobile
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
            return Id + " | " + FirstName + " | " + LastName;
        }
    }
}
