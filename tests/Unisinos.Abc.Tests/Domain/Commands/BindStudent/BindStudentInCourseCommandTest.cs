using Unisinos.Abc.Domain.Commands;

namespace Unisinos.Abc.Tests.Domain.Commands.BindStudent;
public class BindStudentInCourseCommandTest
{
    [Fact]
    public void BindStudentCourseInCommandValid()
    {
        //Arrange
        var command = new BindStudentInCourseCommand(Guid.NewGuid(), Guid.NewGuid());

        //Act
        var result = command.IsValid();

        //Assert
        Assert.Equal(true, command.IsValid());
    }

    [Fact]
    public void BindStudentCourseInCommandStudentInvalid()
    {
        //Arrange
        var command = new BindStudentInCourseCommand(null, Guid.NewGuid());

        //Act
        var errors = command.GetErrors();

        //Assert
        Assert.Equal("O id do estudante é obrigatório",
            errors.Select(x => x).FirstOrDefault());
    }

    [Fact]
    public void BindStudentCourseInCommandCourseInvalid()
    {
        //Arrange
        var command = new BindStudentInCourseCommand(Guid.NewGuid(), null);

        //Act
        var errors = command.GetErrors();

        //Assert
        Assert.Equal("O id do curso é obrigatório", errors.Select(x => x).FirstOrDefault());
    }
}

