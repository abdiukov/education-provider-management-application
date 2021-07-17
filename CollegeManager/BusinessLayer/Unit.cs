namespace Model
{
    /// <summary>
    /// Contains information about a course unit, such as the name of the unit, number of hours required to complete the unit.
    /// Units can belong to multiple clusters. Clusters may belong to multiple courses.
    /// </summary>
    public class Unit
    {
        //CONSTRUCTORS

        /// <param name="UnitID">ID of unit e.g 20</param>
        /// <param name="UnitName">Name of unit e.g Advanced algorithms</param>
        /// <param name="NumberOfHours">Number of hours requried to complete the unit e.g 200</param>
        public Unit(int UnitID, string UnitName, int NumberOfHours)
        {
            this.UnitID = UnitID;
            this.UnitName = UnitName;
            this.NumberOfHours = NumberOfHours;
        }

        /// <param name="UnitName">Name of unit e.g Advanced algorithms</param>
        /// <param name="NumberOfHours">Number of hours requried to complete the unit e.g 200</param>
        public Unit(string UnitName, int NumberOfHours)
        {
            this.UnitName = UnitName;
            this.NumberOfHours = NumberOfHours;
        }

        //PROPERTIES
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int NumberOfHours { get; set; }
        public bool IsSelected { get; set; }
        public string IsSelectedString
        {
            get { return IsSelected ? "Selected" : "Not selected"; }
        }

        //METHODS
        public override string ToString()
        {
            return UnitID + " | " + UnitName + " | Hours: " + NumberOfHours;
        }
    }
}
