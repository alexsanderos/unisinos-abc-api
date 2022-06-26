using MediatR;
using Unisinos.Abc.Domain.Commands;
using Unisinos.Abc.Domain.Entities;
using Unisinos.Abc.Domain.Interfaces;
using Unisinos.Abc.Domain.Notifications;

namespace Unisinos.Abc.Domain.EventsHandlers
{
    public class StudentCommandHandler :
        IRequestHandler<CreateStudentCommand, ResponseCommand>,
        IRequestHandler<BindStudentInCourseCommand, ResponseCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediator _mediator;
        private readonly INotificationService _notification;

        public StudentCommandHandler(
            IStudentRepository studentRepository,
            IMediator mediator,
            INotificationService notification)
        {
            _studentRepository = studentRepository;
            _mediator = mediator;
            _notification = notification;
        }

        public Task<ResponseCommand> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return ResponseError<CreateStudentCommand>(request);
            }

            var student = new Student(
                request.Id,
                request.Name,
                request.Email,
                request.Phone,
                request.Cpf,
                new List<Course>());

            this._studentRepository.Add(student);

            this._mediator.Publish(new StudentCreatedNotification(
                student.Id,
                student.Name,
                student.Email,
                student.Phone,
                student.Cpf));

            return Task.FromResult(new ResponseCommand
            {
                Message = "Estudante criado com sucesso",
                Success = true
            });
        }

        public Task<ResponseCommand> Handle(BindStudentInCourseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return ResponseError<BindStudentInCourseCommand>(request);
            }

            var student = _studentRepository.GetStudent(request.IdStudent);
            var course = _studentRepository.GetCourse(request.IdCourse);

            if (student == null)
            {
                return ResponseError("Estudante não encontrado!");
            }

            if (course == null)
            {
                return ResponseError("Curso não encontrado!");
            }

            if (student.Courses.Any(x => x.Id == course.Id))
            {
                return ResponseError("Estudante já vinculado ao curso!");
            }

            student.AddCourse(course);
            this._studentRepository.Update(student);

            this._mediator.Publish(new BindStudentInCourseNotification(
                    student.Id,
                    course.Id,
                    student.Name,
                    course.Name
                ));

            return Task.FromResult(new ResponseCommand
            {
                Message = "Estudante vinculado ao curso com sucesso!",
                Success = true
            });
        }

        private Task<ResponseCommand> ResponseError(string message)
        {
            _notification.AddNotification(message, false);

            return Task.FromResult(new ResponseCommand
            {
                Message = "Ocorreu um erro!",
                Success = false
            });
        }

        private Task<ResponseCommand> ResponseError<T>(BaseCommand<T> command)
        {
            command.GetErrors().ForEach(error =>
            {
                _notification.AddNotification(error, false);
            });

            return Task.FromResult(new ResponseCommand
            {
                Message = "Ocorreu um erro!",
                Success = false
            });
        }
    }
}