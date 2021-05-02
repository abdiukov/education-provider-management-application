using System;

namespace BusinessLayer
{
    public class Payment
    {

        //PROPERTIES

        public int Id
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public Student PaymentFrom
        {
            get; set;
        }

        public Location PaymentTo
        {
            get; set;
        }

        public bool Status
        {
            get; set;
        }

        public enum PaymentType
        {
            CreditCard = 0,
            Cash = 1,
            Check = 2,
        }

        public double Amount
        {
            get; set;
        }

        //METHODS

        public void AddPayment()
        {
            throw new NotImplementedException();

        }

        public void DeletePayment()
        {
            throw new NotImplementedException();

        }

        public void UpdatePayment()
        {
            throw new NotImplementedException();

        }

        public void SearchPayment()
        {
            throw new NotImplementedException();

        }

        public void ViewAllPayments()
        {
            throw new NotImplementedException();

        }

    }
}
