using BusinessLayer;
using DataLinkLayer;
using System;
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


        public IEnumerable<BusinessLayer.Teacher> GetTeachers(bool sortTheOutput)
        {
            IEnumerable<BusinessLayer.Teacher> unsortedList = control.GetTeachers();

            if (sortTheOutput)
            {
                List<BusinessLayer.Teacher> sortedList = new List<BusinessLayer.Teacher>();
                int idToSortBy = -1;

                foreach (var item in unsortedList)
                {
                    if (idToSortBy != item.Id)
                    {
                        sortedList.Add(item);
                    }
                    idToSortBy = item.Id;
                }
                return sortedList;

            }
            else
            {
                return unsortedList;
            }

        }

        public IEnumerable<BusinessLayer.CourseSelection> GetCourses()
        {
            return control.GetCourses();
        }

        public IEnumerable<BusinessLayer.Delivery> GetDelivery()
        {
            return control.GetDelivery();
        }

        public IEnumerable<BusinessLayer.Student> GetStudents(bool sortTheOutput)
        {
            IEnumerable<BusinessLayer.Student> unsortedList = control.GetStudents();

            if (sortTheOutput)
            {
                List<BusinessLayer.Student> sortedList = new List<BusinessLayer.Student>();
                int idToSortBy = -1;

                foreach (var item in unsortedList)
                {
                    if (idToSortBy != item.Id)
                    {
                        sortedList.Add(item);
                    }
                    idToSortBy = item.Id;
                }
                return sortedList;

            }
            else
            {
                return unsortedList;
            }

        }

        public IEnumerable<BusinessLayer.Student> GetAvailableStudents()
        {
            return control.GetAvailableStudents();
        }


        public IEnumerable<BusinessLayer.Enrolment> GetEnrolmentsByID(int studentID)
        {
            return control.GetEnrolmentsByID(studentID);
        }


        public IEnumerable<BusinessLayer.Location> GetLocations()
        {
            return control.GetLocations();
        }

        public IEnumerable<BusinessLayer.StudentResult> GetStudentResults(int studentID)
        {
            return control.GetStudentResults(studentID);
        }

        public bool AttemptLogin(string username, string password)
        {
            return control.AttemptLogin(username, password);
        }


        public IEnumerable<BusinessLayer.Cluster> GetClusters()
        {
            return control.GetClusters();
        }

        public IEnumerable<BusinessLayer.TeacherCourseHistory> GetTeacherHistoryByID(int teacherID)
        {
            return control.GetTeacherHistoryByID(teacherID);
        }

        public IEnumerable<BusinessLayer.CourseSelection> GetNotOfferedCourses()
        {
            return control.AllNotOfferedCourses();
        }

        public IEnumerable<BusinessLayer.Unit> GetUnallocatedUnits()
        {
            return control.GetUnallocatedUnits();
        }

        public IEnumerable<BusinessLayer.Timetable> GetTimetables()
        {
            return control.GetTimetables();
        }

        public string InsertNewStudent(string address, int genderID, string mobile, string email, string dob,
            string firstName, string lastName, int courseID, double courseCost)
        {
            return control.InsertNewStudent(address, genderID, mobile, email, dob, firstName,
                lastName, courseID, courseCost);
        }


        public string InsertNewTeacher(string address, int genderID, string mobile, string email, string dob,
    string firstName, string lastName, int courseID, int locationID)
        {
            return control.InsertNewTeacher(address, genderID, mobile, email, dob, firstName,
                lastName, courseID, locationID);
        }


        public IEnumerable<BusinessLayer.Gender> GetGenders()
        {
            return control.GetGenders();
        }

        public IEnumerable<BusinessLayer.Semester> GetSemesters()
        {
            return control.GetSemesters();
        }


        public bool InsertCourse(string courseName, int locationID, int deliveryID, Semester startSemester, Semester endSemester,
            double courseCost, List<int> studentIDs, List<int> teacherIDs, List<int> unitIDs)
        {
            int IsCurrent = 0;

            if (endSemester.FinishDate > DateTime.Now)
            {
                IsCurrent = 1;
            }

            int courseID = control.InsertCourse(courseName, locationID, deliveryID, IsCurrent);

            if (courseID == -9999)
            {
                return false;
            }

            foreach (int unitID in unitIDs)
            {
                control.InsertCluster(courseID, unitID);
            }

            foreach (int teacherID in teacherIDs)
            {
                control.InsertCourseTeacher(courseID, teacherID);
            }

            foreach (int studentID in studentIDs)
            {
                control.InsertCourseStudentPayment(studentID, courseID, courseCost);
            }

            for (int i = startSemester.Id; i <= endSemester.Id; i++)
            {
                control.InsertCourseSemester(courseID, i);
            }

            return true;
        }

        public string DeleteTeacher(int teacherID)
        {
            return control.DeleteTeacher(teacherID);
        }

        public string DeleteStudent(int studentID)
        {
            return control.DeleteStudent(studentID);
        }

        public string DeleteUnit(int unitID)
        {
            return control.DeleteUnit(unitID);
        }


        public string EditUnit(int unitID, string unitName, int hoursAmount)
        {
            return control.EditUnit(unitID, unitName, hoursAmount);
        }

        public string EditTeacher(int teacherID, string address, int genderID, string mobile, string email, string dob,
            string firstName, string lastName, int locationID)
        {
            return control.EditTeacher(teacherID, address, genderID, mobile, email, dob, firstName, lastName, locationID);
        }

        public string EditStudent(int studentID, string address, int genderID, string mobile, string email, string dob,
    string firstName, string lastName)
        {
            return control.EditStudent(studentID, address, genderID, mobile, email, dob, firstName, lastName);
        }
        public IEnumerable<Unit> GetUnits()
        {
            return control.GetUnits();
        }

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
