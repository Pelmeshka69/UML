using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher
    {
        public string FullName { get; set; }
        public List<Subject> Subjects { get; set; }

        public bool CanTeach(Subject subject)
        {
            return Subjects.Contains(subject);
        }
    }

    public class Subject
    {
        public string Name { get; set; }
    }

    public class Grade
    {
        public string StudentFullName { get; set; }
        public Subject Subject { get; set; }
        public int Mark { get; set; }
    }

    public class Student
    {
        public string FullName { get; set; }
        public List<Grade> Grades { get; set; }

        public double AverageGrade => Grades.Average(g => g.Mark);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { FullName = "Іван Іванович", Subjects = new List<Subject> { new Subject { Name = "Algebra" }, new Subject { Name = "Geometry" } } },
                new Teacher { FullName = "Петро Петрович", Subjects = new List<Subject> { new Subject { Name = "Ukrainian Language" }, new Subject { Name = "English Language" } } },
                
            };

            
            List<Student> students = new List<Student>
            {
                new Student { FullName = "Олександр Олександрович", Grades = new List<Grade>() },
                new Student { FullName = "Марія Маріївна", Grades = new List<Grade>() },
                
            };

            
            students[0].Grades.Add(new Grade { StudentFullName = "Олександр Олександрович", Subject = new Subject { Name = "Algebra" }, Mark = 12 });
            students[1].Grades.Add(new Grade { StudentFullName = "Марія Маріївна", Subject = new Subject { Name = "Ukrainian Language" }, Mark = 11 });
            

           
            foreach (Student student in students)
            {
                Console.WriteLine($"Учень: {student.FullName}, Середній бал: {student.AverageGrade}");
            }

            foreach (Teacher teacher in teachers)
            {
                foreach (Subject subject in teacher.Subjects)
                {
                    Console.WriteLine($"Вчитель {teacher.FullName} може викладати {subject.Name}");
                }
            }
        }
    }
}