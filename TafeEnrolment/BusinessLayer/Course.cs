using System;

namespace BusinessLayer
{
    public class Course
    {
        //CONSTRUCTOR

        public Course(int Id, string Name, DateTime Duration, int Location, DateTime StartDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Duration = Duration;
            this.Location = Location;
            this.StartDate = StartDate;
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

        public DateTime Duration
        {
            get; set;
        }

        public DateTime StartDate
        {
            get; set;
        }

        public int Location
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
