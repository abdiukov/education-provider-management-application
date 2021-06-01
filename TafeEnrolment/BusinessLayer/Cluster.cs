namespace BusinessLayer
{
    public class Cluster
    {
        //CONSTRUCTOR
        public Cluster(int Id, string UnitName, int HoursAmount)
        {
            this.Id = Id;
            this.UnitName = UnitName;
            this.HoursAmount = HoursAmount;
        }
        //PROPERTIES
        public int Id
        {
            get; set;
        }

        public string UnitName
        {
            get; set;
        }

        public int HoursAmount
        {
            get; set;
        }

    }
}
