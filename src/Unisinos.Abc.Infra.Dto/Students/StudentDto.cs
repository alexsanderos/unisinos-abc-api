using Unisinos.Abc.Infra.Dto.Courses;

namespace Unisinos.Abc.Infra.Dto.Students
{
    public class StudentCourseInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CourseDto Course { get; set; }
    }
}