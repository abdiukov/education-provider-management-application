namespace BusinessLayer
{
    public class Delivery
    {
        //CONSTRUCTOR
        public Delivery(int iD, string deliveryType)
        {
            ID = iD;
            DeliveryType = deliveryType;
        }

        //PROPERTIES
        public int ID
        {
            get; set;
        }
        public string DeliveryType
        {
            get; set;
        }

        //METHODS

        public override string ToString()
        {
            return DeliveryType;
        }
    }
}
