using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Unisinos.Abc.Domain.Commands
{
    public class BindStudentInCourseCommand : BaseCommand<BindStudentInCourseCommand>, IRequest<ResponseCommand>
    {
        public Guid IdStudent { get; private set; }
        public Guid IdCourse { get; private set; }

        public BindStudentInCourseCommand(Guid idStudent, Guid idCourse)
        {
            IdStudent = idStudent;
            IdCourse = idCourse;

            this.Validate();
        }

        public void Validate()
        {
            RuleFor(student => student.IdStudent).NotEmpty().WithMessage("O id do estudante é obrigatório");
            RuleFor(student => student.IdStudent).NotEmpty().WithMessage("O id do curso é obrigatório");

            this.ValidationResult = this.Validate(this);
        }
    }
}