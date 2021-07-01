using System;

namespace BusinessLayer
{
    public class Student : Person
    {
        //CONSTRUCTOR
        public Student(int id, string address, string personGender, string mobile, string email,
            DateTime dateofBirth, string FirstName, string LastName, bool isFeesNotPaid, string Position, bool IsCurrent)
            : base(id, address, personGender, mobile, email, dateofBirth, FirstName, LastName, Position, IsCurrent)
        {
            this.isSelected = false;
            this.isFeesNotPaid = isFeesNotPaid;
        }

        public Student(int Id, string FirstName, string LastName, string Address) : base(Id, FirstName, LastName, Address)
        {
            this.isSelected = false;
        }

        //PROPERTIES

        public bool isFeesNotPaid
        {
            get; set;
        }


        //METHODS

        public override string ToString()
        {
            return Id + " | " + FirstName + " " + LastName + " | " + Address;
        }

    }
}
