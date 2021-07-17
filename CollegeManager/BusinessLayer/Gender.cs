namespace Model
{
    /// <summary>
    /// Contains information about person's gender e.g Male, Female, Other
    /// </summary>
    public class Gender
    {
        //CONSTRUCTOR

        /// <param name="GenderID">ID of gender e.g 3</param>
        /// <param name="GenderDescription">Gender description - what the gender is. E.g Male, Female</param>
        public Gender(int GenderID, string GenderDescription)
        {
            this.GenderID = GenderID;
            this.GenderDescription = GenderDescription;
        }

        //PROPERTIES
        public int GenderID { get; set; }
        public string GenderDescription { get; set; }

        //METHODS
        public override string ToString()
        {
            return GenderDescription;
        }
    }
}
