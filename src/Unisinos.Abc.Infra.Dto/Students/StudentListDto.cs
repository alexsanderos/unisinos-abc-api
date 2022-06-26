using Unisinos.Abc.Infra.Dto.Courses;

namespace Unisinos.Abc.Infra.Dto.Students
{
    public class StudentListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<CourseListDto> Courses { get; set; }
    }
}