using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using System.Data.SqlClient;

namespace ModelLayer
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

        public List<Student> GetStudents()
        {
            List<Student> outputlist = new List<Student>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                      //  Student output = new Student(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                       // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetStudents()\n" + ex);
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
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //  Teacher output = new Teacher(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                        // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetTeachers()\n" + ex);
            }
            //output
            return outputlist;
        }

        public List<Course> GetCourses()
        {
            List<Course> outputlist = new List<Course>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //  Course output = new Course(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                        // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetCourse()\n" + ex);
            }
            //output
            return outputlist;
        }



        public List<Timetable> GetStudentTimetable()
        {
            List<Timetable> outputlist = new List<Timetable>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //  Timetable output = new Timetable(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                        // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetStudentTimetable()\n" + ex);
            }
            //output
            return outputlist;
        }


        public List<PastCourse> GetPastCourses()
        {
            List<PastCourse> outputlist = new List<PastCourse>();

            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);

                //Execute query
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //  PastCourse output = new PastCourse(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                        // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetPastCourses()\n" + ex);
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
                SqlCommand cmd = new SqlCommand("exec sp_SelectOrderHeaders", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //  Location output = new Location(dataReader.GetDateTime(2), dataReader.GetInt32(0), dataReader.GetInt32(1));
                        // outputlist.Add(output);
                    }
                }
                //disposing
                conn.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured at the GetLocations()\n" + ex);
            }
            //output
            return outputlist;
        }

    }
}
