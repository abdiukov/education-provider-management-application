using DataLinkLayer;
using System.Collections.Generic;

namespace ModelLayer
{
    public class Logic
    {
        private readonly Control control;
        /// <summary>
        /// The consturctor links to the Control.cs in the Model Layer
        /// </summary>
        public Logic()
        {
            this.control = new Control();
        }

        //public IEnumerable<BusinessLayer.Teacher> GetTeachers()
        //{
        //    return control.GetTeachers();
        //}

        public IEnumerable<BusinessLayer.Student> GetStudents()
        {
            return control.GetStudents();
        }

        //public IEnumerable<BusinessLayer.Student> GetUnpaidFeesStudents()
        //{
        //    IEnumerable<BusinessLayer.Student> unsorted_students = control.GetStudents();
        //    List<BusinessLayer.Student> output = new List<BusinessLayer.Student>();
        //    foreach (var student in unsorted_students)
        //    {
        //        if (student.paidFees == false)
        //        {
        //            output.Add(student);
        //        }
        //    }
        //    return output;
        //}

        public IEnumerable<BusinessLayer.Location> GetLocations()
        {
            return control.GetLocations();
        }

        //public IEnumerable<BusinessLayer.Timetable> GetStudentTimetable()
        //{
        //    return control.GetStudentTimetable();
        //}

        //public IEnumerable<BusinessLayer.PastCourse> GetTeacherPastCourses()
        //{
        //    return control.GetPastCourses();
        //}

        public IEnumerable<BusinessLayer.Course> GetCourses()
        {
            return control.GetCourses();
        }

        //public IEnumerable<BusinessLayer.Course> GetNotOfferedCourses()
        //{
        //    IEnumerable<BusinessLayer.Course> unsorted_courses = control.GetCourses();
        //    List<BusinessLayer.Course> output = new List<BusinessLayer.Course>();
        //    foreach (var course in unsorted_courses)
        //    {
        //        if (course.isOffered == false)
        //        {
        //            output.Add(course);
        //        }
        //    }
        //    return output;
        //}

        //public IEnumerable<BusinessLayer.Teacher> GetPartTimeTeachers()
        //{
        //    IEnumerable<BusinessLayer.Teacher> unsorted_teachers = control.GetTeachers();
        //    List<BusinessLayer.Teacher> output = new List<BusinessLayer.Teacher>();
        //    foreach (var teacher in unsorted_teachers)
        //    {
        //        if (teacher.Position == "Part Time")
        //        {
        //            output.Add(teacher);
        //        }
        //    }
        //    return output;
        //}


        //public IEnumerable<BusinessLayer.Student> GetPartTimeStudents()
        //{
        //    IEnumerable<BusinessLayer.Student> unsorted_students = control.GetStudents();
        //    List<BusinessLayer.Student> output = new List<BusinessLayer.Student>();
        //    foreach (var student in unsorted_students)
        //    {
        //        if (student.Position == "Part Time")
        //        {
        //            output.Add(student);
        //        }
        //    }
        //    return output;
        //}

        //public IEnumerable<BusinessLayer.Student> GetFullTimeStudents()
        //{
        //    IEnumerable<BusinessLayer.Student> unsorted_students = control.GetStudents();
        //    List<BusinessLayer.Student> output = new List<BusinessLayer.Student>();
        //    foreach (var student in unsorted_students)
        //    {
        //        if (student.Position == "Full Time")
        //        {
        //            output.Add(student);
        //        }
        //    }
        //    return output;
        //}

        //public IEnumerable<BusinessLayer.Teacher> GetFullTimeTeachersOtherThanBasedLocation()
        //{
        //    IEnumerable<BusinessLayer.Teacher> unsorted_teachers = control.GetTeachers();
        //    List<BusinessLayer.Teacher> output = new List<BusinessLayer.Teacher>();
        //    foreach (var teacher in unsorted_teachers)
        //    {
        //        if (teacher.Position == "Full Time" //&& teacher's location is other than based location
        //            )
        //        {
        //            output.Add(teacher);
        //        }
        //    }
        //    return output;
        //}

    }
}
