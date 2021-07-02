namespace BusinessLayer
{
    /// <summary>
    /// Clusters may contain multiple units. Cluster.cs is used to show that information. 
    /// </summary>
    public class Cluster : Unit
    {
        //CONSTRUCTOR

        /// <param name="ClusterID">ID of the Cluster e.g 15</param>
        /// <param name="UnitName">Name of unit that belongs to that Cluster e.g Advanced algorithms </param>
        /// <param name="NumberOfHours">How many hours the unit(that belongs to cluster) contains e.g 200</param>
        public Cluster(int ClusterID, string UnitName, int NumberOfHours) : base(UnitName, NumberOfHours)
        {
            this.ClusterID = ClusterID;
            this.UnitName = UnitName;
        }

        //PROPERTIES
        public int ClusterID { get; set; }
    }
}
