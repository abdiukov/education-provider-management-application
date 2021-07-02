namespace BusinessLayer
{
    /// <summary>
    /// Contains information about how course is delivered e.g Full Time, Part Time, Online
    /// </summary>
    public class Delivery
    {
        //CONSTRUCTOR

        /// <param name="Id">ID of the delivery type e.g 2</param>
        /// <param name="DeliveryType">What the delivery type is. How course is delivered e.g Full Time, Part Time, Online</param>
        public Delivery(int Id, string DeliveryType)
        {
            this.Id = Id;
            this.DeliveryType = DeliveryType;
        }

        //PROPERTIES
        public int Id { get; set; }
        public string DeliveryType { get; set; }

        //METHODS
        public override string ToString()
        {
            return DeliveryType;
        }
    }
}
