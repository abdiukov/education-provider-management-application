namespace BusinessLayer
{
    public class Unit
    {
        public Unit(int id, string name, int numberOfHours)
        {
            Id = id;
            Name = name;
            NumberOfHours = numberOfHours;
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

        public int NumberOfHours
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
            return Id + " | " + Name + " | Hours: " + NumberOfHours;
        }
    }
}
