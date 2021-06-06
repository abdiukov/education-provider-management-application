namespace BusinessLayer
{
    public class Gender
    {
        //CONSTRUCTOR

        public Gender(int GenderID, string GenderDescription)
        {
            this.GenderID = GenderID;
            this.GenderDescription = GenderDescription;
        }

        //PROPERTIES
        public int GenderID
        {
            get; set;
        }
        public string GenderDescription
        {
            get; set;
        }

        public override string ToString()
        {
            return GenderDescription;
        }
    }
}
