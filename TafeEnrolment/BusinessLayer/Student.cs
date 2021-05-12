using System;

namespace BusinessLayer
{
    public class Student
    {

        //CONSTRUCTOR

        public Student(int Id, string Address, Gender StudentGender, int Mobile, string Email, DateTime DateofBirth, string FirstName, string LastName, bool isFeesPaid, bool isFullTime)
        {
            this.Id = Id;
            this.Address = Address;
            this.StudentGender = StudentGender;
            this.Mobile = Mobile;
            this.Email = Email;
            this.DateofBirth = DateofBirth;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.isFeesPaid = isFeesPaid;
            this.isFullTime = isFullTime;
        }

        //PROPERTIES

        public int Id
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

        public int Mobile
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public Gender StudentGender
        {
            get; set;
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public bool isFeesPaid
        {
            get; set;
        }

        public bool isFullTime
        {
            get; set;
        }

        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
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
