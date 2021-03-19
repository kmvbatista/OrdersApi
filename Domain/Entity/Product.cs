using System;

namespace Domain.Entity
{
  public class Product : BaseEntity
  {
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
    public String Name { get; set; }
    public String Description { get; set; }
    private double _price;
    private int _quantity;
    public int Quantity
    {
      get => _quantity;
      set
      {
        if (value > 0)
          _quantity = value;
      }
    }
    public double Price
    {
      get => _price;
      set
      {
        if (value > 0)
          _price = value;
      }
    }
  }
}
