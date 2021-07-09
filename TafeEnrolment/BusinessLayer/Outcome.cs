namespace Model
{
    public class Outcome
    {
        //CONSTRUCTOR

        /// <param name="OutcomeID">ID of outcome e.g 3</param>
        /// <param name="OutcomeDescription">Outcome description  - e.g Satisfactory, Unsatisfacotry</param>
        public Outcome(int OutcomeID, string OutcomeDescription)
        {
            this.OutcomeID = OutcomeID;
            this.OutcomeDescription = OutcomeDescription;
        }

        //PROPERTIES
        public int OutcomeID { get; set; }
        public string OutcomeDescription { get; set; }

        //METHODS
        public override string ToString()
        {
            return OutcomeDescription;
        }
    }
}
