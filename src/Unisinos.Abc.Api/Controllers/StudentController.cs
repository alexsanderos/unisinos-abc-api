using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unisinos.Abc.Domain.Commands;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Infra.Data.Interfaces;
using Unisinos.Abc.Infra.Dto.Students;
using Unisinos.Abc.Infra.Interfaces;

namespace Unisinos.Abc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : BaseController
    {
        private readonly IStudentQuery _studentQuery;
        private readonly IVideoService _videoService;
        private readonly IMediator _mediator;

        public StudentController(
            IStudentQuery studentQuery,
            IVideoService videoService,
            IMediator mediator,
            INotificationService notificationService) : base(notificationService)
        {
            _studentQuery = studentQuery;
            _mediator = mediator;
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentQuery.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
        {
            var createStudent = new CreateStudentCommand(
                dto.Name,
                dto.Email,
                dto.Phone,
                dto.Cpf
            );

            var result = await _mediator.Send(createStudent);

            return GetResult();
        }

        [HttpGet]
        [Route("{idStudent}/courses/{courseId}")]
        public IActionResult GetStudent(Guid idStudent, Guid courseId)
        {
            return Ok(_studentQuery.GetStudent(idStudent, courseId));
        }

        [HttpPost]
        [Route("{idStudent}/courses/{courseId}/bindcourse")]
        public async Task<IActionResult> BindInCourse(Guid idStudent, Guid courseId)
        {
            var result = await _mediator.Send(new BindStudentInCourseCommand(idStudent, courseId));

            return GetResult();
        }
    }
}