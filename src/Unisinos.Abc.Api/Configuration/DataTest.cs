using Unisinos.Abc.Domain.Entities;
using Unisinos.Abc.Infra.Data.Context;

namespace Unisinos.Abc.Api.Configuration
{
    public class DataTest
    {
        public static void AddStudents(UnisinosAbcContext context)
        {

            var courses = new List<Course>();

            courses.Add(new Course(Guid.NewGuid(), "2022/1 - Análise e Modelagem de Sistemas", "AMS-221"));
            courses.Add(new Course(Guid.NewGuid(), "2022/1 - Desenvolvimento de Equipes de Alto Desempenho", "DEAD-221"));
            courses.Add(new Course(Guid.NewGuid(), "2022/1 - Engenharia de Requisitos", "ER-221"));
            courses.Add(new Course(Guid.NewGuid(), "2022/1 - Projeto e Arquitetura de Software", "PAS-221"));

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                var newStudent = new Student(
                    Guid.NewGuid(),
                    "Student " + i,
                    "student" + i + "@unisinos.br",
                    "11" + i + "9888888",
                    "" + i + "123456789"
                );
                courses.ForEach(course => newStudent.AddCourse(course));
                students.Add(newStudent);
            }
            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}