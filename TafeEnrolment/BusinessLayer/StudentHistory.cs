using System;

namespace BusinessLayer
{
    public class StudentHistory
    {

        //PROPERTIES
        public Student student
        {
            get; set;
        }

        public Course StudentCourse
        {
            get; set;
        }

        public DateTime CourseStartDate
        {
            get; set;
        }

        public DateTime CourseEndDate
        {
            get; set;
        }

        public Location CourseLocation
        {
            get; set;
        }

        public enum Outcome
        {
            Satisfactory = 1,
            Unsatisactory = 2,
            In_Progress = 3,
        }

        //METHODS

        public void AddStudentHistory()
        {
            throw new NotImplementedException();

        }

        public void DeleteStudentHistory()
        {
            throw new NotImplementedException();

        }

        public void UpdateStudentHistory()
        {
            throw new NotImplementedException();

        }

        public void SearchStudentHistory()
        {
            throw new NotImplementedException();

        }

        public void ViewAllStudentHistory()
        {
            throw new NotImplementedException();

        }

    }
}
