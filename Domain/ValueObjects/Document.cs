using Domain.Enums;

namespace Domain.ValueObjects
{
  public struct Document
  {
    public Document(string value, DocumentType type)
    {
      _value = value;
      Type = type;
    }
    private string _value;
    public DocumentType Type { get; set; }

    public override string ToString()
    {
      return _value;
    }
  }
}
