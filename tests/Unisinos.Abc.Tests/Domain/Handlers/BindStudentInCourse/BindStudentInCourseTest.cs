using MediatR;
using Moq;
using Unisinos.Abc.Domain.Commands;
using Unisinos.Abc.Domain.Entities;
using Unisinos.Abc.Domain.EventsHandlers;
using Unisinos.Abc.Domain.Interfaces;

namespace Unisinos.Abc.Tests.Domain.Handlers.BindStudentInCourse
{
    public class BindStudentInCourseTest
    {
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<INotificationService> _notification;

        public BindStudentInCourseTest()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _mediator = new Mock<IMediator>();
            _notification = new Mock<INotificationService>();
        }

        [Fact]
        public void HandlerBindStudentInCourseCommandSuccess()
        {
            //Arrange
            var command = new BindStudentInCourseCommand(Guid.NewGuid(), Guid.NewGuid());
            var student = new Student(Guid.NewGuid(), "Pedro", "pedro@gmail.com", "92929901", "01998288188");
            var course = new Course(Guid.NewGuid(), "EG- Software", "EGS");

            _studentRepository.Setup(x => x.GetStudent(It.IsAny<Guid>())).Returns(student);
            _studentRepository.Setup(x => x.GetCourse(It.IsAny<Guid>())).Returns(course);

            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Result.Success);
            Assert.Equal("Estudante vinculado ao curso com sucesso!", result.Result.Message);            
        }

        [Fact]
        public void HandlerBindStudentInCourseCommandInvalidCommand()
        {
            //Arrange
            var command = new BindStudentInCourseCommand(null, Guid.NewGuid());

            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(command, new CancellationToken());

            //Assert
            Assert.False(result.Result.Success);
            Assert.Equal("Ocorreu um erro!", result.Result.Message);
        }

        [Fact]
        public void HandlerBindStudentInCourseCommandCourseNotFound()
        {
            //Arrange
            var command = new BindStudentInCourseCommand(Guid.NewGuid(), Guid.NewGuid());
            var student = new Student(Guid.NewGuid(), "Pedro", "pedro@gmail.com", "92929901", "01998288188");

            _studentRepository.Setup(x => x.GetStudent(It.IsAny<Guid>())).Returns(student);            

            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(command, new CancellationToken());

            //Assert
            Assert.False(result.Result.Success);
            Assert.Equal("Ocorreu um erro!", result.Result.Message);
        }

        [Fact]
        public void HandlerBindStudentInCourseCommandStudentNotFound()
        {
            //Arrange
            var command = new BindStudentInCourseCommand(Guid.NewGuid(), Guid.NewGuid());

            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(command, new CancellationToken());

            //Assert
            Assert.False(result.Result.Success);
            Assert.Equal("Ocorreu um erro!", result.Result.Message);
        }

        [Fact]
        public void HandlerBindStudentInCourseCommandStudentLinkedInCourse()
        {
            //Arrange
            var guidCourse = Guid.NewGuid();
            var guidStudent = Guid.NewGuid();

            var command = new BindStudentInCourseCommand(guidStudent, guidCourse);
            var student = new Student(guidStudent, "Pedro", "pedro@gmail.com", "92929901", "01998288188");
            var course = new Course(guidCourse, "EG- Software", "EGS");
            student.AddCourse(course);

            _studentRepository.Setup(x => x.GetStudent(It.IsAny<Guid>())).Returns(student);
            _studentRepository.Setup(x => x.GetCourse(It.IsAny<Guid>())).Returns(course);


            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(command, new CancellationToken());

            //Assert
            Assert.False(result.Result.Success);
            Assert.Equal("Ocorreu um erro!", result.Result.Message);
        }
    }
}
