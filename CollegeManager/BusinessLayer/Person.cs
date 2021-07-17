using System;

namespace Model
{
    /// <summary>
    /// Abstract class that is inherited by Teacher.cs and Student.cs.
    /// Abstract class contains personal information about a person
    /// </summary>
    public abstract class Person
    {
        //CONSTRUCTORS
        public Person()
        {
        }

        public Person(int Id, string Address, string PersonGender, string Mobile, string Email,
            DateTime DateofBirth, string FirstName, string LastName, string Position, bool IsCurrent)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Mobile = Mobile;
            this.Email = Email;
            this.PersonGender = PersonGender;
            this.DateofBirth = DateofBirth;
            this.Position = Position;
            this.IsCurrent = IsCurrent;
        }

        public Person(int Id, string FirstName, string LastName, string Address)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
        }


        //PROPERTIES
        public string Position { get; set; }
        public bool IsCurrent { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PersonGender { get; set; }
        public string Address { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Mobile { get; set; }
        public bool IsSelected { get; set; }

        public string IsSelectedString
        {
            get { return IsSelected ? "Selected" : "Not selected"; }
        }
    }
}
