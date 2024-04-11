using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ITStepAcademy
{
    public class Student
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int BirthYear { get; set; }
        public Dictionary<string, int> Grades { get; set; } = new Dictionary<string, int>();
    }

    public class Teacher
    {
        public string FullName { get; set; }
    }

    public class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher Teacher { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>();

            while (true)
            {
                Console.WriteLine("1. Add group");
                Console.WriteLine("2. Delete group");
                Console.WriteLine("3. Edit group");
                Console.WriteLine("4. Show group information");
                Console.WriteLine("5. Add student to group");
                Console.WriteLine("6. Change teacher's name"); // Додавання можливості зміни імені вчителю
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Group group = new Group();
                    Console.Write("Enter group name: ");
                    group.Name = Console.ReadLine();
                    Console.Write("Enter teacher's full name: ");
                    group.Teacher = new Teacher { FullName = Console.ReadLine() };
                    groups.Add(group);
                }
                else if (option == 2)
                {
                    Console.Write("Enter the name of the group to delete: ");
                    string groupName = Console.ReadLine();
                    groups.RemoveAll(g => g.Name == groupName);
                }
                else if (option == 3)
                {
                    Console.Write("Enter the name of the group to edit: ");
                    string groupName = Console.ReadLine();
                    Group group = groups.FirstOrDefault(g => g.Name == groupName);
                    if (group != null)
                    {
                        Console.Write("Enter new group name: ");
                        group.Name = Console.ReadLine();
                        Console.Write("Enter new teacher's full name: ");
                        group.Teacher.FullName = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Group not found.");
                    }
                }
                else if (option == 4)
                {
                    Console.Write("Enter the name of the group: ");
                    string groupName = Console.ReadLine();
                    Group group = groups.FirstOrDefault(g => g.Name == groupName);
                    if (group != null)
                    {
                        Console.WriteLine("Group: " + group.Name);
                        Console.WriteLine("Teacher: " + group.Teacher.FullName);
                        Console.WriteLine("Students:");
                        foreach (var student in group.Students)
                        {
                            Console.WriteLine("- Name: " + student.FullName + ", Phone: " + student.Phone + ", Birth Year: " + student.BirthYear);
                            Console.WriteLine("  Grades:");
                            foreach (var grade in student.Grades)
                            {
                                Console.WriteLine("  - " + grade.Key + ": " + grade.Value);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Group not found.");
                    }
                }
                else if (option == 5)
                {
                    Console.Write("Enter the name of the group to add student to: ");
                    string groupName = Console.ReadLine();
                    Group group = groups.FirstOrDefault(g => g.Name == groupName);
                    if (group != null)
                    {
                        Student student = new Student();
                        Console.Write("Enter student's name: ");
                        student.FullName = Console.ReadLine();
                        Console.Write("Enter student's phone: ");
                        student.Phone = Console.ReadLine();
                        Console.Write("Enter student's birth year: ");
                        student.BirthYear = int.Parse(Console.ReadLine());
                        Console.Write("Enter student's programming grade: ");
                        int programmingGrade = int.Parse(Console.ReadLine());
                        student.Grades["Programming"] = programmingGrade;
                        Console.Write("Enter student's 3D modeling grade: ");
                        int modelingGrade = int.Parse(Console.ReadLine());
                        student.Grades["3D Modeling"] = modelingGrade;
                        Console.Write("Enter student's robotics grade: ");
                        int roboticsGrade = int.Parse(Console.ReadLine());
                        student.Grades["Robotics"] = roboticsGrade;

                        group.Students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine("Group not found.");
                    }
                }
                else if (option == 6)
                {
                    Console.Write("Enter the name of the group to change teacher's name: ");
                    string groupName = Console.ReadLine();
                    Group group = groups.FirstOrDefault(g => g.Name == groupName);
                    if (group != null)
                    {
                        Console.Write("Enter new teacher's full name: ");
                        group.Teacher.FullName = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Group not found.");
                    }
                }
                else if (option == 7)
                {
                    SaveGroupsToXml(groups);
                    break;
                }
            }
        }

        static void SaveGroupsToXml(List<Group> groups)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Group>));
            using (TextWriter writer = new StreamWriter("groups.xml"))
            {
                serializer.Serialize(writer, groups);
            }
            Console.WriteLine("Data saved to groups.xml");
        }
    }
}
