using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem
{
    public static class FileManagement
    {
        public static void SaveDataToFile(List<IStudent> students, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine(student.ToDataString());
                }
            }
        }

        public static List<IStudent> LoadDataFromFile(string filePath)
        {
            List<IStudent> students = new List<IStudent>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 3)
                        {
                            string name = parts[0];
                            int rollNumber = int.Parse(parts[1]);
                            char grade = char.Parse(parts[2]);
                            students.Add(new Student(name, rollNumber, grade));
                        }
                    }
                }
            }
            return students;
        }
    }
}