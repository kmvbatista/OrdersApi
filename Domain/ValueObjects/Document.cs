using Domain.Enums;

namespace Domain.ValueObjects
{
  public class Document
  {
    public string Value { get; set; }
    public DocumentType Type { get; set; }
  }
}
