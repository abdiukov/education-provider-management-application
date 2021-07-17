using BusinessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLinkLayer
{
    /// <summary>
    /// Control.cs is responsible for database related operations
    /// </summary>
    public class Control
    {
        //CONSTRUCTOR
        public Control(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //PROPERTIES
        private readonly string connectionString;

        //
        //METHODS TO RETRIEVE DATA FROM DATABASE
        //

        /// <returns>A list of ways how the course can be delivered (Full Time, Part Time, Online) and their respective IDs inside database.</returns>
        public IEnumerable<Delivery> GetDelivery()
        {
            List<Delivery> outputlist = new List<Delivery>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllDelivery", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Delivery output = new Delivery(dataReader.GetInt32(0), dataReader.GetString(1));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetDelivery()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of items that store information about course such as course id, course name, campus name, delivery</returns>
        public IEnumerable<CourseSelection> GetCourses()
        {
            List<CourseSelection> outputlist = new List<CourseSelection>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllCourse", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CourseSelection output = new CourseSelection(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetCourses()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>A list of different genders (Male, Female, Other) and their respective IDs inside database.</returns>
        public IEnumerable<Gender> GetGenders()
        {
            List<Gender> outputlist = new List<Gender>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllGender", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        Gender output = new Gender(dataReader.GetInt32(0), dataReader.GetString(1));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetGenders()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>A list of units that are not allocated to any courses</returns>
        public IEnumerable<Unit> GetUnallocatedUnits()
        {
            List<Unit> outputlist = new List<Unit>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectUnallocatedUnits", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        Unit output = new Unit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnallocatedUnits()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns> A list of all courses and course information</returns>
        public IEnumerable<Timetable> GetTimetables()
        {
            List<Timetable> outputlist = new List<Timetable>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllTimetables", conn);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Timetable output = new Timetable(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDateTime(2),
                            dataReader.GetDateTime(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6),
                            dataReader.GetInt32(7), dataReader.GetInt32(8), dataReader.GetInt32(9),
                            (dataReader[10].ToString() == "True"));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTimetables()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>A list of courses that are currently not being taught</returns>
        public IEnumerable<CourseSelection> AllNotOfferedCourses()
        {
            List<CourseSelection> outputlist = new List<CourseSelection>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllNotOfferedCourse", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CourseSelection output = new CourseSelection(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at AllNotOfferedCourses()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="studentID">ID of student inside the database e.g 10</param>
        /// <returns>List of student results that correspond to the provided student id</returns>
        public List<StudentResult> GetStudentResults(int studentID)
        {

            List<StudentResult> outputlist = new List<StudentResult>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_StudentResultByID @studentID", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        StudentResult output = new StudentResult(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetInt32(4));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudentResults()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of units and which cluster they belong to</returns>
        public List<Cluster> GetClusters()
        {
            List<Cluster> outputlist = new List<Cluster>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllCluster", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        Cluster output = new Cluster(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetClusters()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="teacherID">ID of teacher inside the database e.g 12</param>
        /// <returns>List of all courses the teacher has taught in the past/currently teaches</returns>
        public List<TeacherCourseHistory> GetTeacherHistoryByID(int teacherID)
        {
            List<TeacherCourseHistory> outputlist = new List<TeacherCourseHistory>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectTeacherHistoryByID @teacherID", conn);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        TeacherCourseHistory output = new TeacherCourseHistory(
                            dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                            dataReader.GetString(3), (dataReader[4].ToString() == "True"));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeacherHistoryByID()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of all campus locations including where the campus is located, what the phone number is, what the campus name is.</returns>
        public List<Location> GetLocations()
        {
            List<Location> outputlist = new List<Location>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllLocation", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Location output = new Location(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetLocations()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of untis that don't belong(are not being taught) in the Course ID provided</returns>
        public List<Unit> GetUnitsThatDontBelongToCourse(int courseID)
        {
            List<Unit> outputlist = new List<Unit>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectUnitsThatDontBelongToCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Unit output = new Unit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnitsThatDontBelongToCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of untis that belong(are being taught) in the Course ID provided</returns>
        public List<Unit> GetUnitsThatBelongToCourse(int courseID)
        {
            List<Unit> outputlist = new List<Unit>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectUnitsThatBelongToCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Unit output = new Unit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnitsThatBelongToCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of teachers that teach the Course ID provided</returns>
        public List<Teacher> GetTeachersTeachingCourse(int courseID)
        {
            List<Teacher> outputlist = new List<Teacher>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllTeacherTeachingCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Teacher output = new Teacher(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeachersTeachingCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }


        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of teachers that don't teach the Course ID provided</returns>
        public List<Teacher> GetTeachersNotTeachingCourse(int courseID)
        {
            List<Teacher> outputlist = new List<Teacher>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllTeacherNotTeachingCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Teacher output = new Teacher(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeachersNotTeachingCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of students that attend the Course ID provided</returns>
        public List<Student> GetStudentsAttendingCourse(int courseID)
        {
            List<Student> outputlist = new List<Student>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllStudentsEnrolledIntoCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        {
                            Student output = new Student(dataReader.GetInt32(0), dataReader.GetString(1),
                                dataReader.GetString(2), dataReader.GetString(3));
                            outputlist.Add(output);
                        }
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudentsAttendingCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }


        /// <param name="courseID">ID of course e.g 10</param>
        /// <returns>List of students that don't attend the Course ID provided</returns>
        public List<Student> GetStudentsNotAttendingCourse(int courseID)
        {
            List<Student> outputlist = new List<Student>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllStudentsNotEnrolledIntoCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        {
                            Student output = new Student(dataReader.GetInt32(0), dataReader.GetString(1),
                                dataReader.GetString(2), dataReader.GetString(3));
                            outputlist.Add(output);
                        }
                    }
                    //disposing
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudentsNotAttendingCourse()\n" + ex.Message);
            }
            //output
            return outputlist;
        }


        /// <param name="studentID">ID of student inside the database e.g 10</param>
        /// <returns>List of course enrollments that the student id is enrolled at</returns>
        public List<Enrolment> GetEnrolmentsByID(int studentID)
        {
            List<Enrolment> outputlist = new List<Enrolment>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectEnrolmentById @studentID", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Enrolment output = new Enrolment(dataReader.GetString(0), dataReader.GetString(1),
                            dataReader.GetString(2), double.Parse(dataReader[3].ToString()), double.Parse(dataReader[4].ToString()),
                             dataReader.GetString(5), dataReader.GetString(6), (dataReader[7].ToString() == "True"), dataReader.GetInt32(8));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetEnrolmentsByID()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of information about college semesters, such as when the semester starts, when the semester ends, what the semester is called</returns>
        public List<Semester> GetSemesters()
        {
            List<Semester> outputlist = new List<Semester>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllSemester", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Semester output = new Semester(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDateTime(2), dataReader.GetDateTime(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetSemesters()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of all students who are available - meaning they are not currently enrolled into any course. </returns>
        public List<Student> GetAvailableStudents()
        {
            List<Student> outputlist = new List<Student>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectUnenrolledStudents", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Student output = new Student(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }

                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetAvailableStudents()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of all students, past and present who have attended a college in the past. Includes information such as student personal details, whether the student has paid fees</returns>
        public List<Student> GetStudents()
        {
            List<Student> outputlist = new List<Student>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllStudent", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Student output = new Student(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4),
                            dataReader.GetDateTime(5), dataReader.GetString(6), dataReader.GetString(7),
                           (dataReader[8].ToString() == "1"), dataReader.GetString(9), (dataReader[10].ToString() == "True"));
                        outputlist.Add(output);
                    }
                }

                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudents()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of all teachers( & their personal details) who have taught in the past or are currently teaching.</returns>
        public List<Teacher> GetTeachers()
        {
            List<Teacher> outputlist = new List<Teacher>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllTeacher", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Teacher output = new Teacher(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4),
                            dataReader.GetDateTime(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8),
                             (dataReader[9].ToString() == "True"), (dataReader[10].ToString() != dataReader[11].ToString()), dataReader.GetInt32(10));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeachers()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of units, including unit name, unit id, amount of hours required to complete the unit</returns>
        public List<Unit> GetUnits()
        {
            List<Unit> outputlist = new List<Unit>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllUnit", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Unit output = new Unit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnits()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of different course outcomes and corresponding IDs e.g "Satisfactory", "No outcome available", "Unsatisfactory" </returns>
        public List<Outcome> GetOutcomes()
        {
            List<Outcome> outputlist = new List<Outcome>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllOutcome", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Outcome output = new Outcome(dataReader.GetInt32(0), dataReader.GetString(1));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetOutcomes()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        /// <returns>List of course informations that is used to fill in the "Edit Course" window</returns>
        public List<CourseInformation> GetCoursesForAutofill()
        {
            List<CourseInformation> outputlist = new List<CourseInformation>();
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_GetCourseInfoToAutoFill", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CourseInformation output = new CourseInformation(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetInt32(2), dataReader.GetInt32(3), dataReader.GetInt32(4),
                            dataReader.GetInt32(5));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetCoursesForAutofill()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        //
        //METHODS TO LOG INTO THE DATABASE
        //

        /// <returns>True - the log-in was successful. False - the log-in attempt had failed.</returns>
        public bool CheckConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                conn.Dispose();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //
        //METHODS TO INSERT NEW DATA INTO THE DATABASE
        //

        /// <param name="address">Teacher's residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="genderID">Teacher's gender id e.g 2</param>
        /// <param name="mobile">Teacher's mobile number e.g 0444-323-131</param>
        /// <param name="email">Teacher's email e.g MichaelNorton@gmail.com</param>
        /// <param name="dob">Teacher's date of birth e.g 1993-02-20 (YYYY-MM-DD)</param>
        /// <param name="firstName">Teacher's first name e.g Michael</param>
        /// <param name="lastName">Teacher's last name e.g Nortons</param>
        /// <param name="courseID">The id of the course that the inserted teacher will be teaching e.g 22</param>
        /// <param name="locationID">ID of teacher's base location (main campus where teacher is employed at) e.g 3</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string InsertNewTeacher(string address, int genderID, string mobile, string email,
            string dob, string firstName, string lastName, int courseID, int locationID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertTeacher @address, @genderID, @mobile, @email, @dob, @firstname, @lastname, @base_locationID, @courseID", conn);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@genderID", genderID);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dob));
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName);
                cmd.Parameters.AddWithValue("@base_locationID", locationID);
                cmd.Parameters.AddWithValue("@courseID", courseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher " + firstName + " " + lastName + " has been successfully added to database.\n";
            }
            catch (Exception ex)
            {
                return "Failed to insert new teacher " + firstName + " " + lastName + " .An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="address">Student's residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="genderID">Student's gender id e.g 1</param>
        /// <param name="mobile">Student's mobile number e.g 0444-123-431</param>
        /// <param name="email">Student's email e.g HowardSmith@gmail.com</param>
        /// <param name="dob">Student's date of birth e.g 2003-11-15 (YYYY-MM-DD)</param>
        /// <param name="firstName">Student's first name e.g Howard</param>
        /// <param name="lastName">Student's last name e.g Smith</param>
        /// <param name="courseID">The id of the course that the student will be enrolled at e.g 12</param>
        /// <param name="courseCost">The cost of the course e.g 5000.10</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string InsertNewStudent(string address, int genderID, string mobile, string email, string dob,
            string firstName, string lastName, int courseID, double courseCost)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertStudent @address, @genderID, @mobile, @email, @dob, @firstname, @lastname, @courseID, @amountDue", conn);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@genderID", genderID);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                cmd.Parameters.AddWithValue("@amountDue", courseCost);


                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The student " + firstName + " " + lastName + " has been successfully added to database.\n";
            }
            catch (Exception ex)
            {
                return "Failed to insert new student " + firstName + " " + lastName + " .An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="courseName">The name of the course e.g Certificate II in Plumbing</param>
        /// <param name="locationID">The ID of the location where the course will be offered e.g 2</param>
        /// <param name="deliveryID">The ID on how the course will be delivered e.g 1</param>
        /// <param name="IsCurrent">0 - the course is currently not being taught. 1 - the course is currently being taught</param>
        /// <returns>The ID (in database) of the new course inserted</returns>
        public int InsertCourse(string courseName, int locationID, int deliveryID, int IsCurrent)
        {
            int output = -9999;
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertCourse @name, @locationID, @deliveryID, @IsCurrent", conn);
                cmd.Parameters.AddWithValue("@name", courseName);
                cmd.Parameters.AddWithValue("@locationID", locationID);
                cmd.Parameters.AddWithValue("@deliveryID", deliveryID);
                cmd.Parameters.AddWithValue("@IsCurrent", IsCurrent);

                SqlDataReader dataReader = cmd.ExecuteReader();

                dataReader.Read();

                output = dataReader.GetInt32(0);

                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at InsertCourse()\n" + ex.Message);
            }
            //output
            return output;
        }

        /// <summary>
        /// Inserts a semester that the course belongs to into the database. For example Semester 1 2021.
        /// The insertion happens more than once if the course has more than 1 semester.
        /// </summary>
        /// <param name="courseID">ID of the course e.g 12</param>
        /// <param name="semesterID">ID of the semester e.g 5</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string InsertCourseSemester(int courseID, int semesterID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertCourseSemester @courseID, @semesterID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                cmd.Parameters.AddWithValue("@semesterID", semesterID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The semester ID " + semesterID + " has been successfully added to course ID " + courseID + "\n";

            }
            catch (Exception ex)
            {
                return "Failed to add semester ID " + semesterID + " to course ID " + courseID + ". An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="studentID">ID of the student</param>
        /// <param name="courseID">ID of the course</param>
        /// <param name="courseCost">Total course cost for that specific student e.g 2500.50</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>

        public string InsertCourseStudentPayment(int courseID, int studentID, double courseCost)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertCourseStudentPayment @studentID, @courseID, @amountDue", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                cmd.Parameters.AddWithValue("@amountDue", courseCost);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();

                return "Success. The student id " + studentID + " has been added to course id " + courseID + " with the course cost being " + courseCost + "\n";

            }
            catch (Exception ex)
            {
                return "Failed to alter payment for student id " + studentID + " .An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="courseID">ID of the course e.g 10</param>
        /// <param name="teacherID">ID of the teacher who teaches that course e.g 12</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>

        public string InsertCourseTeacher(int courseID, int teacherID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertCourseTeacher @courseID, @teacherID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher id " + teacherID + " has been appended into course id " + courseID + " .\n";

            }
            catch (Exception ex)
            {
                return "Failed to insert teacher id " + teacherID + " into course id " + courseID + " .An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="courseID">ID of the course</param>
        /// <param name="unitID">ID of the unit that belongs to that course</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string InsertCluster(int courseID, int unitID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertCluster @courseID, @unitID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);
                cmd.Parameters.AddWithValue("@unitID", unitID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The unit id " + unitID + " has been appended into course id " + courseID + " .\n";

            }
            catch (Exception ex)
            {
                return "Failed to insert unit id " + unitID + " into course id " + courseID + " .An error has occured\n" + ex.Message + "\n";
            }
        }


        /// <param name="unitName">New name of unit e.g Advanced algorithms</param>
        /// <param name="hoursAmount">New number of hours requried to complete the unit e.g 200</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>

        public string InsertUnit(string unitName, int hoursAmount)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertUnit @unitName, @hoursAmount", conn);
                cmd.Parameters.AddWithValue("@unitName", unitName);
                cmd.Parameters.AddWithValue("@hoursAmount", hoursAmount);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The unit " + unitName + " has been successfully inserted";
            }
            catch (Exception ex)
            {
                return "Failed to insert unit " + unitName + " .An error had occured \n" + ex.Message + "\n";
            }
        }

        //
        //METHODS TO EDIT/DELETE INFORMATION INSIDE THE DATABASE
        //

        /// <param name="CourseID">ID of course that is being edited</param>
        /// <param name="CourseName">The new name of the course e.g Certificate II in Plumbing</param>
        /// <param name="LocationID">The new ID of the location where the course will be offered e.g 2</param>
        /// <param name="DeliveryID">Ihe new ID on how the course will be delivered e.g 1</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditCourse(int CourseID, string CourseName, int LocationID, int DeliveryID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_EditCourse @CourseID, @CourseName, @LocationID, @DeliveryID", conn);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);
                cmd.Parameters.AddWithValue("@CourseName", CourseName);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@DeliveryID", DeliveryID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The course has been successfully edited.\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit course. An error has occured.\n" + ex.Message + "\n";
            }
        }



        /// <param name="courseStudentID">ID that links specific student to specific course e.g 100 </param>
        /// <param name="amountPaid">The amount that has been paid by student for that specific course e.g 2000.00</param>
        /// <param name="amountDue">Total course cost for that specific student e.g 2500.50</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditStudentPayment(int courseStudentID, double amountPaid, double amountDue)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_AlterPaymentByCourseStudentID @CourseStudentID, @amountPaid, @amountDue", conn);
                cmd.Parameters.AddWithValue("@CourseStudentID", courseStudentID);
                cmd.Parameters.AddWithValue("@amountPaid", amountPaid);
                cmd.Parameters.AddWithValue("@amountDue", amountDue);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The student payment has been changed.\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit student payment. An error has occured \n" + ex.Message + "\n";
            }
        }


        /// <param name="newOutcomeID">The new course outcome ID for the specific student e.g 1</param>
        /// <param name="courseStudentID">ID that links specific student to specific course e.g 100 </param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditStudentOutcome(int newOutcomeID, int courseStudentID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_EditStudentOutcome @newOutcomeID, @courseStudentID", conn);
                cmd.Parameters.AddWithValue("@newOutcomeID", newOutcomeID);
                cmd.Parameters.AddWithValue("@courseStudentID", courseStudentID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The student outcome has been changed.\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit student outcome. An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="studentID">ID of student that is being edited e.g 23</param>
        /// <param name="address">Student's new residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="genderID">Student's new gender id e.g 1</param>
        /// <param name="mobile">Student's new mobile number e.g 0444-123-431</param>
        /// <param name="email">Student's new email e.g HowardSmith@gmail.com</param>
        /// <param name="dob">Student's new date of birth e.g 2003-11-15 (YYYY-MM-DD)</param>
        /// <param name="firstName">Student's new first name e.g Howard</param>
        /// <param name="lastName">Student's new last name e.g Smith</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditStudent(int studentID, string address, int genderID, string mobile,
            string email, string dob, string firstName, string lastName)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_EditStudent @studentID, @address, @genderID, @mobile, @email, @dob, @firstname, @lastname", conn);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@genderID", genderID);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The student has been successfully edited\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit student. An error has occured \n" + ex.Message + "\n";
            }
        }

        /// <param name="teacherID">The id of teacher that is being edited e.g 22</param>
        /// <param name="address">Teacher's new residential address e.g 22 Column Street, Blacktown 2133</param>
        /// <param name="genderID">Teacher's new gender id e.g 2</param>
        /// <param name="mobile">Teacher's new mobile number e.g 0444-323-131</param>
        /// <param name="email">Teacher's new email e.g MichaelNorton@gmail.com</param>
        /// <param name="dob">Teacher's new date of birth e.g 1993-02-20 (YYYY-MM-DD)</param>
        /// <param name="firstName">Teacher's new first name e.g Michael</param>
        /// <param name="lastName">Teacher's new last name e.g Nortons</param>
        /// <param name="locationID">ID of teacher's new base location (main campus where teacher is employed at) e.g 3</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditTeacher(int teacherID, string address, int genderID, string mobile, string email, string dob,
            string firstName, string lastName, int locationID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_EditTeacher @teacherID, @address, @genderID, @mobile, @email, @dob, @firstname, @lastname, @base_locationID", conn);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@genderID", genderID);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dob", DateTime.Parse(dob));
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName);
                cmd.Parameters.AddWithValue("@base_locationID", locationID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher has been successfully edited\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit teacher. An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="unitID">ID of the unit that will be modified</param>
        /// <param name="unitName">New name of unit e.g Advanced algorithms</param>
        /// <param name="hoursAmount">New number of hours requried to complete the unit e.g 200</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string EditUnit(int unitID, string unitName, int hoursAmount)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_EditUnit @unitID, @unitName, @hoursAmount", conn);
                cmd.Parameters.AddWithValue("@unitID", unitID);
                cmd.Parameters.AddWithValue("@unitName", unitName);
                cmd.Parameters.AddWithValue("@hoursAmount", hoursAmount);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The unit has been successfully edited\n";
            }
            catch (Exception ex)
            {
                return "Failed to edit unit. An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="unitID">ID of the unit that will be deleted e.g 20</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteUnit(int unitID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteUnit @unitID", conn);
                cmd.Parameters.AddWithValue("@unitID", unitID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The unit has been successfully deleted\n";
            }
            catch (Exception ex)
            {
                return "Failed to delete unit. An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <summary>
        /// Makes it so that unit does no longer belong to specific course
        /// </summary>
        /// <param name="CourseID">ID of course where the unit is being removed from e.g 10</param>
        /// <param name="unitID">ID of the unit that will be removed from course e.g 20</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteCluster(int CourseID, int unitID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteCluster @unitID, @CourseID", conn);
                cmd.Parameters.AddWithValue("@unitID", unitID);
                cmd.Parameters.AddWithValue("@CourseID", CourseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The unit id " + unitID + " has been removed from course id " + CourseID + " .\n";
            }
            catch (Exception ex)
            {
                return "Failed to remove unit id " + unitID + " from course id " + CourseID + " .An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <summary>
        /// Removes a semester from course
        /// </summary>
        /// <param name="CourseID">ID of course where the semester is being removed form e.g 10</param>
        /// <param name="SemesterID">ID of semester which is being removed from course e.g 4</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteCourseSemester(int CourseID, int SemesterID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteCourseSemester @courseID, @semesterID", conn);
                cmd.Parameters.AddWithValue("@courseID", CourseID);
                cmd.Parameters.AddWithValue("@semesterID", SemesterID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The semester id " + SemesterID + " has been removed from course id " + CourseID + " .\n";
            }
            catch (Exception ex)
            {
                return "Failed to semester id " + SemesterID + " from course id " + CourseID + " .An error has occured\n" + ex.Message + "\n";
            }
        }


        /// <param name="courseID">ID of course where we wish to remove the teacher from e.g 12</param>
        /// <param name="teacherID">ID of teacher who is being removed from course e.g 10</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>

        public string DeleteCourseTeacher(int courseID, int teacherID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteCourseTeacher @TeacherID, @CourseID", conn);
                cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher id " + teacherID + " has been removed from course id " + courseID + " .\n";

            }
            catch (Exception ex)
            {
                return "Failed to remove teacher id " + teacherID + " from course id " + courseID + " .An error has occured\n" + ex.Message + "\n";
            }
        }


        /// <param name="courseID">ID of course where the student payment is being removed from e.g 12 </param>
        /// <param name="studentID">ID of student whose course payment is being removed e.g 120</param>

        public void DeleteCourseStudentPayment(int courseID, int studentID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteCourseStudentPayment @studentID, @courseID", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.Parameters.AddWithValue("@courseID", courseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at DeleteCourseStudentPayment()\n" + ex.Message);
            }
        }

        /// <param name="studentID">ID of the student that will be deleted e.g 10</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteStudent(int studentID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteStudent @studentID", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The student has been successfully deleted\n";
            }
            catch (Exception ex)
            {
                return "Failed to delete student. An error has occured\n" + ex.Message + "\n";
            }
        }

        /// <param name="teacherID">ID of the teacher that will be deleted e.g 12</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteTeacher(int teacherID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteTeacher @teacherID", conn);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher has been successfully deleted\n";
            }
            catch (Exception ex)
            {
                return "Failed to delete teacher. An error has occured \n" + ex.Message + "\n";
            }
        }


        /// <param name="courseID">ID of course that is being deleted from database e.g 10</param>
        /// <returns>Success/Failure message that will be displayed to the user</returns>
        public string DeleteCourse(int courseID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_DeleteCourse @courseID", conn);
                cmd.Parameters.AddWithValue("@courseID", courseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The course has been successfully deleted\n";
            }
            catch (Exception ex)
            {
                return "Failed to delete course. An error has occured.\n" + ex.Message + "\n";
            }
        }

    }
}
