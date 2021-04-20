using Domain.Entity;
using Domain.Enums;
using Tests.Builders;
using Xunit;

namespace Tests.EntitiesTests
{
  public class CustomerTests
  {
    [Fact]
    public void ShoudBeValidCustomerWithCPF()
    {
      var customer = GetCustomerWithCPFExample();
      Assert.True(IsCustomerValid(customer));
    }

    [Fact]
    public void ShoudBeValidCustomerWithCNPJ()
    {
      Customer customer = GetCustomerWithCNPJExample();
      Assert.True(IsCustomerValid(customer));
    }


    [Fact]
    public void NewCustomerShouldBeActive()
    {
      var customer = GetCustomerWithCPFExample();
      Assert.True(customer.IsActive);
    }

    [Fact]
    public void ShoudNotBeValidWhenNameIsWrong()
    {
      var customer = GetCustomerWithCPFExample();
      customer.Name = "AAA";
      Assert.False(IsCustomerValid(customer));
      Assert.Equal("O nome do cliente precisa ter mais que 3 caracteres", customer.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShoudNotBeValidWhenCPFIsWrong()
    {
      var customer = GetCustomerWithCPFExample();
      customer.Document = new Domain.ValueObjects.Document("14831224676", DocumentType.CPF);
      Assert.False(IsCustomerValid(customer));
      Assert.Equal("O documento inserido está inválido", customer.ValidationResult.Errors[0].ErrorMessage);
    }

    [Fact]
    public void ShoudNotBeValidWhenCNPJIsWrong()
    {
      var customer = GetCustomerWithCPFExample();
      customer.Document = new Domain.ValueObjects.Document("77375774000121", DocumentType.CNPJ);
      Assert.False(IsCustomerValid(customer));
      Assert.Equal("O documento inserido está inválido", customer.ValidationResult.Errors[0].ErrorMessage);
    }

    private Customer GetCustomerWithCPFExample()
    {
      return new CustomerBuilder().WithDocument(documentType: Domain.Enums.DocumentType.CPF,
                                                 documentValue: "26223692048")
                                                .WithName("kennedy")
                                                .Construct();
    }

    private Customer GetCustomerWithCNPJExample()
    {
      return new CustomerBuilder().WithDocument(documentType: Domain.Enums.DocumentType.CNPJ,
                                                 documentValue: "77375774000121")
                                                .WithName("Kennedy Co.")
                                                .Construct();
    }

    private bool IsCustomerValid(Customer customer)
    {
      customer.Validate();
      return customer.IsValid;
    }
  }
}
