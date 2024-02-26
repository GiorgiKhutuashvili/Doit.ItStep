using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataFilePath = "students.txt";
            StudentManagement system = new StudentManagement(dataFilePath);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Student Management System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Update Student's Grade");
                Console.WriteLine("4. Update Student's Name");
                Console.WriteLine("5. Remove Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            system.AddStudent();
                            break;
                        case 2:
                            system.ShowAllStudents();
                            break;
                        case 3:
                            system.UpdateStudentGrade();
                            break;
                        case 4:
                            system.UpdateStudentName();
                            break;
                        case 5:
                            system.RemoveStudent();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }
}