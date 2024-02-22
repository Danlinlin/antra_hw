public class Department
{
    public Instructor2 Head { get; set; } 
    public decimal Budget { get; set; }
    public DateTime BudgetStart { get; set; }
    public DateTime BudgetEnd { get; set; }
    public List<Course> OfferedCourses { get; set; }

    public Department(Instructor2 head, decimal budget, DateTime budgetStart, DateTime budgetEnd)
    {
        Head = head;
        Budget = budget;
        BudgetStart = budgetStart;
        BudgetEnd = budgetEnd;
        OfferedCourses = new List<Course>();
    }

    public void AddCourse(Course course)
    {
        OfferedCourses.Add(course);
    }
}