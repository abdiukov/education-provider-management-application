using System;

namespace BusinessLayer
{
    public class Teacher : Person
    {

        //CONSTRUCTOR
        public Teacher(int id, string address, string personGender, string mobile, string email,
            DateTime dateofBirth, string FirstName, string LastName,
            string Position, bool IsCurrent, bool OtherThanBaseLocation,
            int BaseLocation)
            : base(id, address, personGender, mobile, email, dateofBirth, FirstName, LastName, Position, IsCurrent)
        {
            this.Position = Position;
            this.OtherThanBaseLocation = OtherThanBaseLocation;
            this.BaseLocation = BaseLocation;
        }

        //PROPERTIES

        public string Position
        {
            get; set;
        }

        public bool OtherThanBaseLocation
        {
            get; set;
        }

        public int BaseLocation
        {
            get; set;
        }
        //METHODS

        public override string ToString()
        {
            return Id + " | " + FirstName + " | " + LastName;
        }
    }
}
