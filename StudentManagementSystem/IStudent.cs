namespace StudentManagementSystem
{
    public interface IStudent
    {
        string Name { get; set; }
        int RollNumber { get; set; }
        char Grade { get; set; }

        void Display();
        string ToDataString();
    }
}