namespace BusinessLayer
{
    /// <summary>
    /// Clusters may contain multiple units. Cluster.cs is used to show that information. 
    /// </summary>
    public class Cluster
    {
        //CONSTRUCTOR

        /// <param name="ClusterID">ID of the Cluster e.g 15</param>
        /// <param name="UnitName">Name of unit that belongs to that Cluster e.g Advanced algorithms </param>
        /// <param name="HoursAmount">How many hours the unit(that belongs to cluster) contains e.g 200</param>
        public Cluster(int ClusterID, string UnitName, int HoursAmount)
        {
            this.ClusterID = ClusterID;
            this.UnitName = UnitName;
            this.HoursAmount = HoursAmount;
        }

        //PROPERTIES

        public int ClusterID { get; set; }
        public string UnitName { get; set; }
        public int HoursAmount { get; set; }
    }
}
