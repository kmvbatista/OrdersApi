using System;
using Domain.Enums;

namespace Domain.Models.CustomerModels
{
  public abstract class CustomerModel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public DocumentType DocumentType { get; set; }
  }
}
