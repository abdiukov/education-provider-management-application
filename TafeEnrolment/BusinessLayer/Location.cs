namespace BusinessLayer
{
    /// <summary>
    /// Contains information about a campus - where the campus is located, what the phone number is, what is campus name.
    /// </summary>
    public class Location
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of the location e.g 15</param>
        /// <param name="Name">Name of the campus e.g Granville</param>
        /// <param name="Address">Address of the campus e.g 12 Church Street, Parramatta NSW 2150</param>
        /// <param name="LocationContactNumber">The phone number that can be used to contact the campus e.g 0400-123-456 </param>
        public Location(int Id, string Name, string Address, string LocationContactNumber)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.LocationContactNumber = LocationContactNumber;
        }

        //PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LocationContactNumber { get; set; }

        //METHODS
        public override string ToString()
        {
            return Name;
        }

    }
}
