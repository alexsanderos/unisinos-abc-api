using Unisinos.Abc.Infra.Data.Context;
using Unisinos.Abc.Infra.Data.Interfaces;
using Unisinos.Abc.Infra.Dto.Courses;
using Unisinos.Abc.Infra.Dto.Students;
using Unisinos.Abc.Infra.Interfaces;

namespace Unisinos.Abc.Infra.Data.Queries
{
    public class StudentQuery : IStudentQuery
    {
        private readonly UnisinosAbcContext _context;
        private readonly IVideoService _videoService;

        public StudentQuery(UnisinosAbcContext context, IVideoService videoService)
        {
            _context = context;
            _videoService = videoService;
        }

        public IEnumerable<StudentListDto> GetAll()
        {
            return _context.Students.Select(x => new StudentListDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Courses = x.Courses.Select(c => new CourseListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Key = c.Key
                }).ToList()
            });
        }

        public StudentCourseInfoDto GetStudent(Guid id, Guid courseId)
        {

            StudentCourseInfoDto studentDto = _context.Students.Where(x => x.Id == id)
            .Select(x => new StudentCourseInfoDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Course = x.Courses.Where(c => c.Id == courseId).Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Key = c.Key
                }).FirstOrDefault()
            }).FirstOrDefault();

            if (studentDto != null && studentDto.Course != null)
            {
                studentDto.Course.Videos = _videoService.GetVideos(studentDto.Course.Key).Result;
            }

            return studentDto;
        }
    }
}