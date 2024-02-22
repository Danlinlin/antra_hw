public class Course
{
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public char Grade { get; set; }
    public Instructor2 Instructor { get; set; }
    public List<Student2> EnrolledStudents { get; set; }

    public Course(string courseId, string courseName)
    {
        CourseId = courseId;
        CourseName = courseName;
        EnrolledStudents = new List<Student2>();
    }
}