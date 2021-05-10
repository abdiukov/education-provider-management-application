namespace BusinessLayer
{
    public class Cluster
    {
        //CONSTRUCTOR
        public Cluster(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
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

    }
}
