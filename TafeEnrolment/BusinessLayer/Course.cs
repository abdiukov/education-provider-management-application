using System;

namespace BusinessLayer
{
    public class Course
    {
        //CONSTRUCTOR

        public Course(int Id, string Name, string Location, string Delivery)
        {
            this.Id = Id;
            this.Name = Name;
            this.Location = Location;
            this.Delivery = Delivery;
        }

        //PROPERTIES
        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Delivery
        {
            get; set;
        }

        public DateTime Duration
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public string Location
        {
            get; set;
        }

        //public List<Semester> CourseSemesters
        //{
        //    get; set;
        //}
        //public List<Unit> UnitsLinkedToCourse
        //{
        //    get; set;
        //}


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
