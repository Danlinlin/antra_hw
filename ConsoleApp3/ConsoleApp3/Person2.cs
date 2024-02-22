public abstract class Person2
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public List<string> Addresses { get; set; }

    protected Person2(string name, DateTime birthdate)
    {
        Name = name;
        Birthdate = birthdate;
        Addresses = new List<string>();
    }
}

public class Student2 : Person2, IStudentService
{
    public List<Course> Courses { get; set; }

    public Student2(string name, DateTime birthdate) : base(name, birthdate) { }

    public void CalculateAge()
    {
        int age = DateTime.Today.Year - Birthdate.Year;
        if (Birthdate.Date > DateTime.Today.AddYears(-age)) age--;
        Console.WriteLine($"{Name} is {age} years old.");
    }

    public decimal CalculateSalary()
    {
        return 0;
    }

    public IEnumerable<string> GetAddresses()
    {
        return Addresses;
    }

    public void CalculateGPA()
    {
        if (Courses.Count == 0)
        {
            Console.WriteLine("No courses to calculate GPA.");
            return;
        }

        double totalPoints = 0;
        int totalCourses = 0;

        foreach (var course in Courses)
        {
            switch (course.Grade)
            {
                case 'A':
                    totalPoints += 4.0;
                    break;
                case 'B':
                    totalPoints += 3.0;
                    break;
                case 'C':
                    totalPoints += 2.0;
                    break;
                case 'D':
                    totalPoints += 1.0;
                    break;
            }
            totalCourses++;
        }

        double gpa = totalPoints / totalCourses;
        Console.WriteLine($"The GPA is: {gpa:N2}");
    }
}

public class Instructor2 : Person2, IInstructorService
{
    public DateTime JoinDate { get; set; }
    public bool IsHeadOfDepartment { get; set; }

    public Instructor2(string name, DateTime birthdate) : base(name, birthdate) { }

    public void CalculateAge()
    {
        int age = DateTime.Today.Year - Birthdate.Year;
        if (Birthdate.Date > DateTime.Today.AddYears(-age)) age--;
        Console.WriteLine($"{Name} is {age} years old.");
    }

    public decimal CalculateSalary()
    {
        return 50000; 
    }

    public IEnumerable<string> GetAddresses()
    {
        return Addresses;
    }

    public void CalculateExperience()
    {
        int experience = DateTime.Today.Year - JoinDate.Year;
        if (JoinDate.Date > DateTime.Today.AddYears(-experience)) experience--;
        Console.WriteLine($"{Name} has {experience} years experience.");
    }
}
