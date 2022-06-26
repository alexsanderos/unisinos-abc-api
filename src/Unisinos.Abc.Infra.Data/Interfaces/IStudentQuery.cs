using Unisinos.Abc.Infra.Dto.Students;

namespace Unisinos.Abc.Infra.Data.Interfaces
{
    public interface IStudentQuery
    {
        public IEnumerable<StudentListDto> GetAll();
        public StudentCourseInfoDto GetStudent(Guid id, Guid courseId);
    }
}