using Domain.Validators.DocumentValidators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validators
{
  public class DocumentValidator : AbstractValidator<Document>
  {
    public DocumentValidator()
    {
      RuleFor(d => d)
        .Must(document => IsDocumentValid(document));
    }

    private bool IsDocumentValid(Document document)
    {
      if (document.Type == Enums.DocumentType.CPF)
        return IsCPFValid(document.ToString());
      return IsCNPJValid(document.ToString());
    }

    private bool IsCNPJValid(string cnpj)
    {
      return new CpfValidator(cnpj).IsValid();
    }

    private bool IsCPFValid(string cpf)
    {
      return new CpfValidator(cpf).IsValid();
    }

  }
}
