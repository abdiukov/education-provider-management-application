using BusinessLayer;
using DataLinkLayer;
using System;
using System.Collections.Generic;

namespace ModelLayer
{
    /// <summary>
    /// 
    /// </summary>
    public class Logic
    {
        private readonly Control control;
        private readonly Type controlType;
        /// <summary>
        /// The consturctor links to the Control.cs in the Model Layer
        /// </summary>
        public Logic()
        {
            control = new Control();
            controlType = control.GetType();
        }


        public IEnumerable<object> GetFromDB(string command)
        {
            return (IEnumerable<object>)controlType.GetMethod(command).Invoke(control, null);
        }

        public IEnumerable<object> GetFromDB(string command, object[] parameters)
        {
            return (IEnumerable<object>)controlType.GetMethod(command).Invoke(control, parameters);
        }

        public string ManageDB(string command, object[] parameters)
        {
            return (string)controlType.GetMethod(command).Invoke(control, parameters);
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


        public bool AttemptLogin(string username, string password)
        {
            return control.AttemptLogin(username, password);
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

    }
}
