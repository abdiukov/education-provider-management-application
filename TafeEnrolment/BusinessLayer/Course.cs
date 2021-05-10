using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Course
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

        public int Duration
        {
            get; set;
        }

        public Location CourseLocation
        {
            get; set;
        }

        public List<Semester> CourseSemesters
        {
            get; set;
        }


        public List<Unit> UnitsLinkedToCourse
        {
            get; set;
        }


        //METHODS

        public void AddCourse()
        {
            throw new NotImplementedException();
        }

        public void DeleteCourse()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse()
        {
            throw new NotImplementedException();
        }

        public void SearchCourse()
        {
            throw new NotImplementedException();
        }

        public void ViewAllCourses()
        {
            throw new NotImplementedException();
        }


        //public bool isOffered
        //{
        //    get; set;
        //}

        //public List<Student> Students
        //{
        //    get; set;
        //}

        //public List<Teacher> Teachers
        //{
        //    get; set;
        //}

        //public List<Unit> CourseUnits
        //{
        //    get; set;
        //}

        //public DateTime courseStartDate
        //{
        //    get; set;
        //}

        //public DateTime courseEndDate
        //{
        //    get; set;
        //}

        //public string courseStatus
        //{
        //    get; set;
        //}

    }
}
