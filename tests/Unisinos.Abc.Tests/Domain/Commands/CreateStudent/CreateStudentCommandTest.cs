using Unisinos.Abc.Domain.Commands;

namespace Unisinos.Abc.Tests.Domain.Commands.CreateStudent;
public class CreteStudentCommandTest
{
    [Fact]
    public void CreateStudentCommandValidCommand()
    {
        //Arrange
        var command = new CreateStudentCommand(
            "Carlos",
            "carlos@gmail.com",
            "9992888192",
            "00892919928");

        //Act
        var result = command.IsValid();

        //Assert
        Assert.Equal(true, command.IsValid());
    }

    [Fact]
    public void CreateStudentCommandInvalidNameCommand()
    {
        //Arrange
        var command = new CreateStudentCommand(
            null,
            "carlos@gmail.com",
            "9992888192",
            "00892919928");

        //Act
        var errors = command.GetErrors();


        //Assert
        Assert.Equal("O nome do estudante é obrigatório",
            errors.Select(x => x).FirstOrDefault());
    }

    [Fact]
    public void CreateStudentCommandInvalidEmailCommand()
    {
        //Arrange
        var command = new CreateStudentCommand(
            "Carlos",
            null,
            "9992888192",
            "00892919928");

        //Act
        var errors = command.GetErrors();

        //Assert
        Assert.Equal("O e-mail do estudante é obrigatório",
            errors.Select(x => x).FirstOrDefault());
    }

    [Fact]
    public void CreateStudentCommandInvalidCpfCommand()
    {
        //Arrange
        var command = new CreateStudentCommand(
            "Carlos",
            "carlos@gmail.com",
            "9982771882",
            null);

        //Act
        var errors = command.GetErrors();

        //Assert
        Assert.Equal("O CPF do estudante é obrigatório",
            errors.Select(x => x).FirstOrDefault());
    }
}

