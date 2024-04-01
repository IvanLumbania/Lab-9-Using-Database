using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_9_Using_Database
{

    public class CourseManager
    {
        private string connectionString;

        public CourseManager(string connectionString) 
        { 
            this.connectionString = connectionString;
        }
        //Getting all the values of all the courses in the database
        public List<Course> GetAllStudents()
        {
            List<Course> CourseList = new List<Course>();


            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM course";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Adding each course to the CourseList
                        while (reader.Read())
                        {
                            CourseList.Add(new Course
                            {
                                CourseID = Convert.ToInt32(reader["CourseID"]),
                                CourseName = reader["CourseName"].ToString(),
                                Credits = Convert.ToInt32(reader["Credits"]),
                            });
                        }
                    }
                }
            }
            return CourseList;
        }

        //Adding Courses
        public void AddCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO course " + "(CourseName, Credits) VALUES (@Name, @Credits)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Updating course
        public void UpdateCourse (Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE course SET CourseName = @Name," + "Credits = @Credits " +"WHERE CourseID = @ID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", course.CourseID);
                    cmd.Parameters.AddWithValue("@Name", course.CourseName);
                    cmd.Parameters.AddWithValue("@Credits", course.Credits);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Deleting specfic course with the matching ID
        public void DeleteCourse(Course course)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM course WHERE CourseID = @ID";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", course.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
