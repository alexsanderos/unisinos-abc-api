using Unisinos.Abc.Domain.Entities;

namespace Unisinos.Abc.Domain.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student student);
        Student GetStudent(Guid id);
        Course GetCourse(Guid idCourse);
        void Update(Student student);
    }
}