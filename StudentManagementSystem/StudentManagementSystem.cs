using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class StudentManagement
    {
        private readonly List<IStudent> students;
        private readonly string dataFilePath;

        public StudentManagement(string dataFilePath)
        {
            this.dataFilePath = dataFilePath;
            students = FileManagement.LoadDataFromFile(dataFilePath);
        }

        public void AddStudent()
        {
            string firstName;
            do
            {
                Console.Write("Enter student's first name: ");
                firstName = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First name cannot be empty. Please try again.");
                }
                else if (!IsAllLetters(firstName))
                {
                    Console.WriteLine("Invalid input. First name must contain only letters.");
                    firstName = "";
                }
            } while (string.IsNullOrWhiteSpace(firstName));

            string lastName;
            do
            {
                Console.Write("Enter student's last name (surname): ");
                lastName = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("Last name (surname) cannot be empty. Please try again.");
                }
                else if (!IsAllLetters(lastName))
                {
                    Console.WriteLine("Invalid input. Last name must contain only letters.");
                    lastName = "";
                }
            } while (string.IsNullOrWhiteSpace(lastName));

            string fullName = $"{firstName} {lastName}";

            int rollNumber;
            bool validRollNumber = false;
            do
            {
                Console.Write("Enter student roll number: ");
                string rollNumberInput = Console.ReadLine();
                if (!int.TryParse(rollNumberInput, out rollNumber))
                {
                    Console.WriteLine("Invalid input. Roll number must be a number.");
                }
                else if (students.Exists(s => s.RollNumber == rollNumber))
                {
                    Console.WriteLine("Student with the same roll number already exists. Please enter a unique roll number.");
                }
                else
                {
                    validRollNumber = true;
                }
            } while (!validRollNumber);

            char grade = ' ';
            bool validGrade = false;
            do
            {
                Console.Write("Enter student grade (A to F): ");
                string gradeInput = Console.ReadLine().ToUpper();
                if (gradeInput.Length != 1 || gradeInput[0] < 'A' || gradeInput[0] > 'F')
                {
                    Console.WriteLine("Invalid input. Grade must be a letter between A and F.");
                }
                else
                {
                    grade = gradeInput[0];
                    validGrade = true;
                }
            } while (!validGrade);

            students.Add(new Student(fullName, rollNumber, grade));

            SaveDataToFile();
            Console.WriteLine("Student added successfully.");
        }

        private bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }


        public void ShowAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (var student in students)
                {
                    student.Display();
                }
            }
        }

        public void UpdateStudentName()
        {
            Console.Write("Enter student's roll number to update name: ");
            int rollNumber;
            if (!int.TryParse(Console.ReadLine(), out rollNumber))
            {
                Console.WriteLine("Invalid input. Roll number must be a number.");
                return;
            }

            var studentToUpdate = students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (studentToUpdate != null)
            {
                string firstName;
                do
                {
                    Console.Write("Enter student's new first name: ");
                    firstName = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.WriteLine("First name cannot be empty. Please try again.");
                    }
                    else if (!IsAllLetters(firstName))
                    {
                        Console.WriteLine("Invalid input. First name must contain only letters.");
                        firstName = "";
                    }
                } while (string.IsNullOrWhiteSpace(firstName));

                string lastName;
                do
                {
                    Console.Write("Enter student's new last name (surname): ");
                    lastName = Console.ReadLine().Trim();
                    if (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.WriteLine("Last name (surname) cannot be empty. Please try again.");
                    }
                    else if (!IsAllLetters(lastName))
                    {
                        Console.WriteLine("Invalid input. Last name must contain only letters.");
                        lastName = "";
                    }
                } while (string.IsNullOrWhiteSpace(lastName));

                string newName = $"{firstName} {lastName}";

                studentToUpdate.Name = newName;

                SaveDataToFile();
                Console.WriteLine("Student name updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found with the given roll number.");
            }
        }

        public void UpdateStudentGrade()
        {
            Console.Write("Enter student's roll number to update grade: ");
            int rollNumber;
            if (!int.TryParse(Console.ReadLine(), out rollNumber))
            {
                Console.WriteLine("Invalid input. Roll number must be a number.");
                return;
            }

            var studentToUpdate = students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (studentToUpdate != null)
            {
                char newGrade = ' ';
                bool validGrade = false;
                do
                {
                    Console.Write($"Current grade for {studentToUpdate.Name} is {studentToUpdate.Grade}. Enter new grade: ");
                    string gradeInput = Console.ReadLine().ToUpper();
                    if (gradeInput.Length != 1 || gradeInput[0] < 'A' || gradeInput[0] > 'F')
                    {
                        Console.WriteLine("Invalid input. Grade must be a letter between A and F.");
                    }
                    else
                    {
                        newGrade = gradeInput[0];
                        validGrade = true;
                    }
                } while (!validGrade);

                studentToUpdate.Grade = newGrade;
                SaveDataToFile();
                Console.WriteLine("Grade updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found with the given roll number.");
            }
        }

        public void RemoveStudent()
        {
            Console.Write("Enter student's roll number to remove: ");
            int rollNumber;
            if (!int.TryParse(Console.ReadLine(), out rollNumber))
            {
                Console.WriteLine("Invalid input. Roll number must be a number.");
                return;
            }

            var studentToRemove = students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                SaveDataToFile();
                Console.WriteLine("Student removed successfully.");
            }
            else
            {
                Console.WriteLine("Student not found with the given roll number.");
            }
        }

        private void SaveDataToFile()
        {
            FileManagement.SaveDataToFile(students, dataFilePath);
        }
    }
}
