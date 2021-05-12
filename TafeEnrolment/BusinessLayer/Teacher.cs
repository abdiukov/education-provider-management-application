using System;

namespace BusinessLayer
{
    public class Teacher
    {

        //CONSTRUCTOR
        public Teacher(int id, string address, Gender teacherGender, int mobile, string email, DateTime dateofBirth, string FirstName, string LastName)
        {
            Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            Address = address;
            Mobile = mobile;
            Email = email;
            TeacherGender = teacherGender;
            DateofBirth = dateofBirth;
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
        public string Email
        {
            get; set;
        }

        public Gender TeacherGender
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public DateTime DateofBirth
        {
            get; set;
        }

        public int Mobile
        {
            get; set;
        }

        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }

        public bool TeacherOtherThanBaseLocation
        {
            get; set;
        }


        //METHODS

        public void AddTeacher()
        {
            throw new NotImplementedException();

        }

        public void DeleteTeacher()
        {
            throw new NotImplementedException();

        }

        public void UpdateTeacher()
        {
            throw new NotImplementedException();

        }

        public void SearchTeacher()
        {
            throw new NotImplementedException();

        }

        public void ViewAllTeachers()
        {
            throw new NotImplementedException();


        }

        public void AssignTimetable()
        {
            throw new NotImplementedException();

        }

        //public bool OtherThanBaseLocation
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

        //public List<Course> currentCourses
        //{
        //    get; set;
        //}

        //public List<PastCourse> pastCourses
        //{
        //    get; set;
        //}

    }
}
