using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Student
    {

        //PROPERTIES

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public Location StudentLocation
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

        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public List<Course> StudentCourses
        {
            get; set;
        }

        //METHODS

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
