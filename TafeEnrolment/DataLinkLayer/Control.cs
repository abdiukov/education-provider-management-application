using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLinkLayer
{
    public class Control
    {
        readonly public string _connectionString;
        /// <summary>
        /// Constructor for Control class
        /// Connects to the Repository class and sets up the connection string
        /// </summary>
        public Control()
        {
            Repository conn_string = new Repository();
            _connectionString = conn_string._connectionString;
        }

        public List<Assessment> GetAssessments()
        {
            List<Assessment> outputlist = new List<Assessment>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllAssessment", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        Assessment output = new Assessment(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetDateTime(2), dataReader.GetDateTime(3),
                            (Assessment.AssessmentType)dataReader.GetInt32(4));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetAssessments()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetAssessments()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetAssessments()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public IEnumerable<CourseSelection> GetCourses()
        {
            List<CourseSelection> outputlist = new List<CourseSelection>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetCourses()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetCourses()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetCourses()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public string InsertNewTeacher(string address, int genderID, string mobile, string email, string dob, string firstName, string lastName, int courseID, int locationID)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand
                    ("exec usp_InsertTeacher @address, @genderID, @mobile, @email, @dob, @firstname, @lastname, @base_locationID, @courseID", conn);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@genderID", genderID);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName);
                cmd.Parameters.AddWithValue("@base_locationID", locationID);
                cmd.Parameters.AddWithValue("@courseID", courseID);

                cmd.ExecuteNonQuery();

                //disposing
                conn.Dispose();
                cmd.Dispose();
                return "Success. The teacher has been successfully inserted";
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                return "Failed to insert new teacher. Primary key violation has occured at InsertNewTeacher()\n" + ex.Message;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return "Failed to insert new teacher. Foreign key violation has occured at InsertNewTeacher()\n" + ex.Message;
            }
            catch (Exception ex)
            {
                return "Failed to insert new teacher. An error has occured at InsertNewTeacher()\n" + ex.Message;
            }
        }

        public string InsertNewStudent(string address, int genderID, string mobile, string email, string dob,
            string firstName, string lastName, int courseID, double courseCost)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
                return "Success. The student has been successfully inserted";
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                return "Failed to insert new student. Primary key violation has occured at InsertNewStudent()\n" + ex.Message;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return "Failed to insert new student. Foreign key violation has occured at InsertNewStudent()\n" + ex.Message;
            }
            catch (Exception ex)
            {
                return "Failed to insert new student. An error has occured at InsertNewStudent()\n" + ex.Message;
            }
        }

        public IEnumerable<Gender> GetGenders()
        {
            List<Gender> outputlist = new List<Gender>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetGenders()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetGenders()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetGenders()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public IEnumerable<Cluster> GetUnallocatedUnits()
        {
            List<Cluster> outputlist = new List<Cluster>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectUnallocatedUnits", conn);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetUnallocatedUnits()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetUnallocatedUnits()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnallocatedUnits()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public IEnumerable<Timetable> GetTimetables()
        {
            List<Timetable> outputlist = new List<Timetable>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetTimetables()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetTimetables()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTimetables()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public IEnumerable<NotOfferedCourse> AllNotOfferedCourses()
        {
            List<NotOfferedCourse> outputlist = new List<NotOfferedCourse>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllNotOfferedCourse", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        NotOfferedCourse output = new NotOfferedCourse(dataReader.GetInt32(0), dataReader.GetString(1),
                            dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at AllNotOfferedCourses()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at AllNotOfferedCourses()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at AllNotOfferedCourses()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<StudentResult> GetStudentResults(int studentID)
        {

            List<StudentResult> outputlist = new List<StudentResult>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_StudentResultByID @studentID", conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        StudentResult output = new StudentResult(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetStudentResults()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetStudentResults()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudentResults()\n" + ex.Message);
            }
            //output
            return outputlist;
        }
        public List<Cluster> GetClusters()
        {
            List<Cluster> outputlist = new List<Cluster>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetClusters()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetClusters()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetClusters()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Course> GetTeacherHistoryByID(int teacherID)
        {
            List<Course> outputlist = new List<Course>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectTeacherHistoryByID @teacherID", conn);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Course output = new Course(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                            dataReader.GetInt32(3), dataReader.GetString(4), dataReader.GetString(5),
                            (dataReader[6].ToString() == "True"));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetTeacherHistoryByID()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetTeacherHistoryByID()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeacherHistoryByID()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Location> GetLocations()
        {
            List<Location> outputlist = new List<Location>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetLocations()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetLocations()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetLocations()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Enrolment> GetEnrolmentsByID(int studentID)
        {
            List<Enrolment> outputlist = new List<Enrolment>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
                            dataReader.GetString(2), Double.Parse(dataReader[3].ToString()), Double.Parse(dataReader[4].ToString()),
                             dataReader.GetString(5), dataReader.GetString(6), (dataReader[7].ToString() == "True"));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetEnrolmentsByID()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetEnrolmentsByID()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetEnrolmentsByID()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Semester> GetSemesters()
        {
            List<Semester> outputlist = new List<Semester>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetSemesters()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetSemesters()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetSemesters()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Student> GetStudents()
        {
            List<Student> outputlist = new List<Student>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

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
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetStudents()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetStudents()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetStudents()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> outputlist = new List<Teacher>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

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
                             (dataReader[9].ToString() == "True"), (dataReader[10].ToString() != dataReader[11].ToString()));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetTeachers()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetTeachers()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetTeachers()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public List<Unit> GetUnits()
        {
            List<Unit> outputlist = new List<Unit>();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_SelectAllUnit", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Unit output = new Unit(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetInt32(2), dataReader.GetString(4));
                        outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at GetUnits()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at GetUnits()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at GetUnits()\n" + ex.Message);
            }
            //output
            return outputlist;
        }

        public bool AttemptLogin(string username, string password)
        {
            bool result = false;
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec usp_AttemptLogin @username, @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    result = (dataReader[0].ToString() == "1");
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                Console.WriteLine("Primary key violation has occured at AttemptLogin()\n" + ex.Message);
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                Console.WriteLine("Foreign key violation has occured at AttemptLogin()\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at AttemptLogin()\n" + ex.Message);
            }
            return result;
        }

    }
}
