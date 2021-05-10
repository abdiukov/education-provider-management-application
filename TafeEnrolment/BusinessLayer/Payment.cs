using System;

namespace BusinessLayer
{
    public class Payment
    {
        //CONSTRUCTOR
        public Payment(int Id, DateTime Date, bool Status, PaymentType paymentType, double Amount)
        {
            this.Id = Id;
            this.Date = Date;
            this.Status = Status;
            this.paymentType = paymentType;
            this.Amount = Amount;
        }

        //PROPERTIES
        public int Id
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public bool Status
        {
            get; set;
        }

        public PaymentType paymentType
        {
            get; set;
        }

        public double Amount
        {
            get; set;
        }

        public enum PaymentType
        {
            CreditCard = 0,
            Cash = 1,
            Check = 2,
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
