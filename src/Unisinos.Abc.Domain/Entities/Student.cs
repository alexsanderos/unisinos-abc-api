namespace Unisinos.Abc.Domain.Entities;

public class Student
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Cpf { get; private set; }
    public ICollection<Course> Courses { get; private set; }


    public Student(Guid id, string name, string email, string phone, string cpf)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Cpf = cpf;
        Courses = new List<Course>();
    }

    public Student(Guid id, string name, string email, string phone, string cpf, List<Course> courses)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
        Cpf = cpf;
        Courses = courses;
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }
}
