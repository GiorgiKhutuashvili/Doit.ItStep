namespace StudentManagementSystem
{
    public class Student : IStudent
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }

        public string ToDataString()
        {
            return $"{Name},{RollNumber},{Grade}";
        }
    }
}