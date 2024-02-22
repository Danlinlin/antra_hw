using System;
using System.Collections.Generic;

public interface IPersonService
{
    void CalculateAge();
    decimal CalculateSalary();
    IEnumerable<string> GetAddresses();
}

public interface IStudentService : IPersonService
{
    void CalculateGPA();
}

public interface IInstructorService : IPersonService
{
    void CalculateExperience();
}

public interface ICourseService
{
    void EnrollStudent(Student2 student);
    void GradeStudent(Student2 student, char grade);
}

public interface IDepartmentService
{
    void AllocateBudget(decimal amount);
}



