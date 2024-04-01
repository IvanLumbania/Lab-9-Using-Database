using MySqlConnector;

namespace Lab_9_Using_Database
{
    public class Program
    {
        static void Main(string[] args)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "",
                Database = "studentdb"
            };
            Console.WriteLine(builder.ConnectionString);
            CourseManager course = new CourseManager(builder.ConnectionString);

            List<Course> CourseList = course.GetAllStudents();

            Console.WriteLine("Current Courses");
            foreach(var courses in  CourseList) 
            {
                Console.WriteLine(courses);
            }

            //Adding a new course
            Console.WriteLine("Adding new course");
            Course course1 = new Course
            {
                CourseName = "Test 1 Subject",
                Credits = 3
            };

            course.AddCourse(course1);
            Console.WriteLine("Course added!");

            //Uodating a course
            Console.WriteLine("Updating course....");
            Course updateCourse = new Course
            {
                CourseID = 1004,
                CourseName = "Updated Test 1",
                Credits = 4
            };

            course.UpdateCourse(updateCourse);
            Console.WriteLine("Course Updated!");

            //Deleting a course
            Console.WriteLine("Deleting a course...");
            Course deleteCourse = new Course
            {
                CourseID = 1003,
            };
            course.DeleteCourse(deleteCourse);
            Console.WriteLine("Course Deleted!");

            //Updated Course
            Console.WriteLine("Updated Courses!!");
            foreach (var courses in CourseList)
            {
                Console.WriteLine(courses);
            }
        }
    }
}
