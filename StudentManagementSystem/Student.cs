namespace StudentManagementSystem
{
    // Class representing a regular student
    public class Student : IStudent
    {
        // Properties for encapsulation
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        // Constructor
        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

        // Method to display student information
        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }

        // Method to convert student information to string
        public string ToDataString()
        {
            return $"{Name},{RollNumber},{Grade}";
        }
    }
}