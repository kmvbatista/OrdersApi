using System;
using Domain.Enums;

namespace Domain.Models.Customer
{
  public class CustomerRequestModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DocumentType DocumentType { get; set; }
  }
}
