using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Unisinos.Abc.Domain.Commands
{
    public class CreateStudentCommand : BaseCommand<CreateStudentCommand>, IRequest<ResponseCommand>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Cpf { get; private set; }
        private ValidationResult ValidationResult;

        public CreateStudentCommand(string name, string email, string phone, string cpf)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            Cpf = cpf;

            this.Validate();
        }

        public void Validate()
        {
            RuleFor(student => student.Name).NotEmpty().WithMessage("O nome do estudante é obrigatório");
            RuleFor(student => student.Cpf).NotEmpty().WithMessage("O CPF do estudante é obrigatório");
            RuleFor(student => student.Email).NotEmpty().WithMessage("O e-mail do estudante é obrigatório");

            this.ValidationResult = this.Validate(this);
        }

        public bool IsValid()
        {
            return this.ValidationResult.IsValid;
        }

        public List<string> GetErrors()
        {
            return this.ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }


    }
}