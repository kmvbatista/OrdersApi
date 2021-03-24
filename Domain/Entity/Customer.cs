using System;
using System.Collections.Generic;
using Domain.Enums;
using Domain.Models.CustomerModels;
using Domain.ValueObjects;

namespace Domain.Entity
{
  public class Customer : BaseEntity
  {
    public Customer(string name, string documentValue, DocumentType documentType)
    {
      SetProperties(name: name, documentType: documentType, documentValue: documentValue);
    }

    public Customer() { }

    public String Name { get; set; }
    public Document Document { get; set; }
    public virtual IList<Order> Orders { get; }

    public void Update(CustomerRequestModel customerReqModel)
    {
      SetProperties(name: customerReqModel.Name,
                    documentType: customerReqModel.DocumentType,
                    documentValue: customerReqModel.Document);
    }

    public override bool Equals(object customer)
    {
      Customer customerParsed = (Customer)customer;
      return Name == customerParsed.Name
             && Document.ToString() == customerParsed.Document.ToString();
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    private void SetProperties(string name, string documentValue, DocumentType documentType)
    {
      Name = name;
      Document = new Document(value: documentValue, type: documentType);
    }

    public override void Validate()
    {
      ValidateFromSubClass(this);
    }
  }
}
