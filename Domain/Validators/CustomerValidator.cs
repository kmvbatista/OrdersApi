using Domain.Entity;
using FluentValidation;

namespace Domain.Validators
{
  public class CustomerValidator : AbstractValidator<Customer>
  {
    public CustomerValidator()
    {
      RuleFor(c => c.Name.Length).GreaterThan(3)
        .WithMessage("O nome do cliente precisa ter mais que 3 caracteres");
      RuleFor(c => c.Document).SetValidator(new DocumentValidator())
                              .WithMessage("O documento inserido está inválido");
    }
  }
}
