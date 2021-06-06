namespace BusinessLayer
{
    public class Location
    {

        //CONSTRUCTOR
        public Location(int id, string name, string address, string locationContactNumber)
        {
            Id = id;
            Name = name;
            Address = address;
            LocationContactNumber = locationContactNumber;
        }

        //PROPERTIES
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string LocationContactNumber
        {
            get; set;
        }

        //METHODS

        public override string ToString()
        {
            return Name;
        }

    }
}
