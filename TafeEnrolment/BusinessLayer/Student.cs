using System;

namespace BusinessLayer
{
    public class Student
    {

        //CONSTRUCTOR

        public Student(int Id, string Address, string StudentGender, string Mobile, string Email, DateTime DateofBirth, string FirstName, string LastName, bool isFeesNotPaid, string Position, bool isCurrent)
        {
            this.Id = Id;
            this.Address = Address;
            this.StudentGender = StudentGender;
            this.Mobile = Mobile;
            this.Email = Email;
            this.DateofBirth = DateofBirth;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.isFeesNotPaid = isFeesNotPaid;
            this.Position = Position;
            this.isCurrent = isCurrent;
        }

        //PROPERTIES

        public string Position
        {
            get; set;
        }

        public int Id
        {
            get; set;
        }
        public string StudentGender
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string Mobile
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public bool isFeesNotPaid
        {
            get; set;
        }

        public bool isCurrent
        {
            get; set;
        }


        public void AddStudent()
        {
            throw new NotImplementedException();

        }

        public void DeleteStudent()
        {
            throw new NotImplementedException();

        }

        public void UpdateStudent()
        {
            throw new NotImplementedException();

        }

        public void SearchStudent()
        {
            throw new NotImplementedException();

        }

        public void ViewAllStudents()
        {
            throw new NotImplementedException();

        }

        public void EnrollStudent()
        {
            throw new NotImplementedException();

        }

        public void CreateResult()
        {
            throw new NotImplementedException();

        }

        public void UnenrollStudent()
        {
            throw new NotImplementedException();

        }

        //public bool paidFees
        //{
        //    get; set;
        //}
        //public string FirstName
        //{
        //    get; set;
        //}

        //public string LastName
        //{
        //    get; set;
        //}

        //public string Position
        //{
        //    get; set;
        //}

        //public string Location
        //{
        //    get; set;
        //}

        //public Timetable timetable
        //{
        //    get; set;
    }
}
