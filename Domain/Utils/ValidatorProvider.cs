using Domain.Entity;
using Domain.Validators;
using FluentValidation;

namespace Domain.Utils
{
  public class ValidatorProvider
  {
    public static IValidator GetValidator<T>(T entity)
    {
      if (entity is Customer)
        return new CustomerValidator();
      return null;
    }
  }
}
