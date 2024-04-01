using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_Using_Database
{
    public class Course
    {
        //Properties
        [Required]
        [PrimaryKey,AutoIncrement]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]

        public int Credits { get; set; }

        public Course() 
        { 
        }
        //Display
        public override string ToString()
        {
            return $"ID : {CourseID}\t" +
                $"Name: {CourseName}\t" +
                $"Credits: {Credits}\t"; 
        }
    }
}
