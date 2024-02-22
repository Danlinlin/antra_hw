using System;

abstract class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    protected Person(string name)
    {
        this.name = name;
    }

    public abstract void Display();

    public virtual decimal CalculateSalary()
    {
        return 0;
    }
}

class Student : Person
{
    private string course;

    public string Course
    {
        get { return course; }
        set { course = value; }
    }
    public Student(string name, string course) : base(name)
    {
        this.course = course;
    }

    public override void Display()
    {
        Console.WriteLine($"{Name} is a student enrolled in {Course}.");
    }
    public override decimal CalculateSalary()
    {
        return 0; 
    }

}

class Instructor : Person
{
    private string department;

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public Instructor(string name, string department) : base(name)
    {
        this.department = department;
    }

    public override void Display()
    {   
        Console.WriteLine($"{Name} is an instructor in the {Department} department.");
    }
    public override decimal CalculateSalary()
    {
        decimal salary = 50000;
        return salary;
    }
}
