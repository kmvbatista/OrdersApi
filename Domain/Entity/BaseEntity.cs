using Domain.Utils;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
  public abstract class BaseEntity
  {
    public Guid Id { get; protected set; }
    public bool IsActive { get; private set; } = true;
    [NotMapped]
    public bool IsValid { get; private set; }
    [NotMapped]
    public ValidationResult ValidationResult { get; private set; }

    public void Deactivate()
    {
      IsActive = false;
    }

    public void Activate()
    {
      IsActive = true;
    }

    protected bool ValidateFromSubClass<T>(T instance)
    {
      var validator = (AbstractValidator<T>)ValidatorProvider.GetValidator(this);
      ValidationResult = validator.Validate(instance);
      return IsValid = ValidationResult.IsValid;
    }

    /// <summary>
    /// Must call super classe's Validate method
    /// </summary>
    public abstract void Validate();
  }
}
