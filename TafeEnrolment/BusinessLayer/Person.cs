using System;

namespace BusinessLayer
{
    public abstract class Person
    {
        //CONSTRUCTOR
        public Person(int id, string address, string personGender, string mobile, string email,
            DateTime dateofBirth, string FirstName, string LastName, string Position, bool isCurrent)
        {
            Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Address = address;
            Mobile = mobile;
            Email = email;
            PersonGender = personGender;
            DateofBirth = dateofBirth;
            this.Position = Position;
            this.isCurrent = isCurrent;
        }

        public Person(int Id, string FirstName, string LastName, string Address)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
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

        public string PersonGender
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
    }
}
