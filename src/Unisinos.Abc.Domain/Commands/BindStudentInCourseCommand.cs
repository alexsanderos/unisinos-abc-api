using FluentValidation;
using MediatR;

namespace Unisinos.Abc.Domain.Commands
{
    public class BindStudentInCourseCommand : BaseCommand<BindStudentInCourseCommand>, IRequest<ResponseCommand>
    {
        public Nullable<Guid> IdStudent { get; private set; }
        public Nullable<Guid> IdCourse { get; private set; }

        public BindStudentInCourseCommand(Nullable<Guid> idStudent, Nullable<Guid> idCourse)
        {
            IdStudent = idStudent;
            IdCourse = idCourse;

            this.Validate();
        }

        public void Validate()
        {
            RuleFor(student => student.IdStudent).NotEmpty().WithMessage("O id do estudante é obrigatório");
            RuleFor(student => student.IdCourse).NotEmpty().WithMessage("O id do curso é obrigatório");

            this.ValidationResult = this.Validate(this);
        }
    }
}