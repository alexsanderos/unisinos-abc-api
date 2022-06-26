using FluentValidation;
using FluentValidation.Results;

namespace Unisinos.Abc.Domain.Commands
{
    public abstract class BaseCommand<T> : AbstractValidator<T>
    {
        public ValidationResult ValidationResult;
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