using Unisinos.Abc.Infra.Dto.Infra;

namespace Unisinos.Abc.Infra.Dto.Courses
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public VideoData Videos { get; set; }
    }
}