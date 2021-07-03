using BusinessLayer;
using DataLinkLayer;
using System;
using System.Collections.Generic;

namespace ModelLayer
{
    /// <summary>
    /// Logic.cs is responsible for communicating with Data Access Layer and performing controller-related methods.
    /// </summary>
    public class Logic
    {
        //CONSTRUCTOR

        /// <summary>
        /// The consturctor links to the Control.cs in the Model Layer
        /// </summary>
        public Logic()
        {
            control = new Control();
            controlType = control.GetType();
        }

        //PROPERTIES
        private readonly Control control;
        private readonly Type controlType;

        //METHODS

        /// <summary>
        /// Generic method that is used to retrieve a list of objects from the database.
        /// Can only be used in methods that do not require any paramaters passed onto them.
        /// </summary>
        /// <param name="command">The name of the method in Control.cs such as GetDelivery</param>
        /// <returns>List of objects e.g list of Students, list of Teachers</returns>
        public IEnumerable<object> GetFromDB(string command)
        {
            return (IEnumerable<object>)controlType.GetMethod(command).Invoke(control, null);
        }

        /// <summary>
        /// Generic method that is used to retrieve a list of objects from the database.
        /// Can be used in methods that require parameters passed onto them.
        /// </summary>
        /// <param name="command">The name of the method in Control.cs such as GetStudentResults</param>
        /// <param name="parameters">The parameters that the method needs such as string address, int genderID, string mobile, string email.</param>
        /// <returns>List of objects e.g list of Students, list of Teachers</returns>
        public IEnumerable<object> GetFromDB(string command, object[] parameters)
        {
            return (IEnumerable<object>)controlType.GetMethod(command).Invoke(control, parameters);
        }

        /// <summary>
        /// Generic method that is used to insert/edit/delete data in the database.
        /// Can be used in methods that require parameters passed onto them.
        /// </summary>
        /// <param name="command">The name of the method in Control.cs such as InsertNewTeacher</param>
        /// <param name="parameters">The parameters that the method needs such as string address, int genderID, string mobile, string email.</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string ManageDB(string command, object[] parameters)
        {
            return (string)controlType.GetMethod(command).Invoke(control, parameters);
        }

        /// <param name="username">Username that is needed to log-in e.g usern2m3 </param>
        /// <param name="password">Password that is needed to log-in e.g greatp@ssw0rd </param>
        /// <returns>True - the log-in was successful. False - the log-in attempt had failed.</returns>
        public bool AttemptLogin(string username, string password)
        {
            return control.AttemptLogin(username, password);
        }

        /// <param name="courseName">The name of the new course e.g Certificate II in Plumbing</param>
        /// <param name="locationID">The ID of the location where the course will be offered e.g 2</param>
        /// <param name="deliveryID">The ID on how the course will be delivered e.g 1</param>
        /// <param name="startSemester">ID of semester when the course starts</param>
        /// <param name="endSemester">ID of semester when the course ends</param>
        /// <param name="courseCost">The cost of the course for all the students enrolled</param>
        /// <param name="studentIDs">The list of student IDs that will be enrolled in the new course</param>
        /// <param name="teacherIDs">The list of teacher IDs who will be teaching the course</param>
        /// <param name="unitIDs">The list of unit IDs that will be taught in the course</param>
        /// <returns>True - a course has been successfully inserted. False - failed to insert a course.</returns>
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

        /// <param name="unsortedList">List where some teacher IDs repeat more than once</param>
        /// <returns>Sorted list where every teacher ID is unique</returns>
        public List<Teacher> SortTeacherList(IEnumerable<Teacher> unsortedList)
        {

            List<Teacher> sortedList = new List<Teacher>();

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

        /// <param name="unsortedList">List where some student IDs repeat more than once</param>
        /// <returns>Sorted list where every student ID is unique</returns>
        public List<Student> SortStudentList(IEnumerable<Student> unsortedList)
        {
            List<Student> sortedList = new List<Student>();

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



    }
}
