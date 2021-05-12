using System;

namespace BusinessLayer
{
    public class Payment
    {
        //CONSTRUCTOR
        public Payment(int Id, DateTime Date, bool Status, double AmountPaid, double AmountDue)
        {
            this.Id = Id;
            this.Status = Status;
            this.AmountPaid = AmountPaid;
            this.AmountDue = AmountDue;
        }

        //PROPERTIES
        public int Id
        {
            get; set;
        }

        public bool Status
        {
            get; set;
        }

        public double AmountPaid
        {
            get; set;
        }

        public double AmountDue
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
