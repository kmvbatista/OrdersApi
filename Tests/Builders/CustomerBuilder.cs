using System;
using Domain.Entity;
using Domain.Enums;
using Domain.ValueObjects;

namespace Tests.Builders
{
  public class CustomerBuilder
  {
    private Guid _id;
    private string _name;

    private Document _document;

    public Customer Construct()
    {
      return new Customer(name: _name, documentType: _document.Type, documentValue: _document.ToString());
    }

    public CustomerBuilder WithId(Guid id)
    {
      _id = id;
      return this;
    }

    public CustomerBuilder WithName(string name)
    {
      _name = name;
      return this;
    }

    public CustomerBuilder WithDocument(DocumentType documentType, string documentValue)
    {
      _document = new Document(documentValue, documentType);
      return this;
    }
  }


}
