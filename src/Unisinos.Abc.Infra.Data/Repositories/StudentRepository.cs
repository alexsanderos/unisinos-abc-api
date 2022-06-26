using Microsoft.EntityFrameworkCore;
using Unisinos.Abc.Domain.Entities;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Infra.Data.Context;

namespace Unisinos.Abc.Infra.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UnisinosAbcContext _context;

        public StudentRepository(UnisinosAbcContext context)
        {
            _context = context;
        }

        public Student GetStudent(Guid id)
        {
            return _context.Students.Where(x => x.Id == id)
                 .Select(x => new Student(
                    x.Id,
                    x.Name,
                    x.Phone,
                    x.Cpf,
                    x.Cpf,
                    x.Courses.Select(x => x).ToList()
                 ))
                .FirstOrDefault();
        }

        public Course GetCourse(Guid idCourse)
        {
            return _context.Courses.Where(x => x.Id == idCourse)
                .FirstOrDefault();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}