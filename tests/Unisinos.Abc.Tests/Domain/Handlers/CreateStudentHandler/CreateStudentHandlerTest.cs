using MediatR;
using Moq;
using Unisinos.Abc.Domain.Commands;
using Unisinos.Abc.Domain.EventsHandlers;
using Unisinos.Abc.Domain.Interfaces;

namespace Unisinos.Abc.Tests.Domain.Handlers.CreateStudentHandler
{
    public class CreateStudentHandlerTest
    {
        private readonly Mock<IStudentRepository> _studentRepository;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<INotificationService> _notification;

        public CreateStudentHandlerTest()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _mediator = new Mock<IMediator>();
            _notification = new Mock<INotificationService>();
        }

        [Fact]
        public void HandlerCreateStudentCommandSuccess()
        {
            //Arrange
            var createStudent = new CreateStudentCommand(
                "Carlos",
                "carlos@gmail.com",
                "99299199292",
                "01889910029"
            );
            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(createStudent, new CancellationToken());

            //Assert
            Assert.True(result.Result.Success);
            Assert.Equal("Estudante criado com sucesso", result.Result.Message);
        }

        [Fact]
        public void HandlerCreateStudentCommandErrorCommand()
        {
            //Arrange
            var createStudent = new CreateStudentCommand(
                null,
                "carlos@gmail.com",
                "99299199292",
                "01889910029"
            );
            var handler = new StudentCommandHandler(
                _studentRepository.Object,
                _mediator.Object,
                _notification.Object);

            //Act
            var result = handler.Handle(createStudent, new CancellationToken());

            //Assert
            Assert.False(result.Result.Success);
            Assert.Equal("Ocorreu um erro!", result.Result.Message);
        }
    }
}
