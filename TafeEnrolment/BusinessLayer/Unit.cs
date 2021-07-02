namespace BusinessLayer
{
    /// <summary>
    /// Contains information about a course unit, such as the name of the unit, number of hours required to complete the unit.
    /// Units can belong to multiple clusters. Clusters may belong to multiple courses.
    /// </summary>
    public class Unit
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of unit e.g 20</param>
        /// <param name="Name">Name of unit e.g Advanced algorithms</param>
        /// <param name="NumberOfHours">Number of hours requried to complete the unit e.g 200</param>
        public Unit(int Id, string Name, int NumberOfHours)
        {
            this.Id = Id;
            this.Name = Name;
            this.NumberOfHours = NumberOfHours;
        }

        //PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfHours { get; set; }
        public bool IsSelected { get; set; }
        public string IsSelectedString
        {
            get { return IsSelected ? "Selected" : "Not selected"; }
        }

        //METHODS
        public override string ToString()
        {
            return Id + " | " + Name + " | Hours: " + NumberOfHours;
        }
    }
}
