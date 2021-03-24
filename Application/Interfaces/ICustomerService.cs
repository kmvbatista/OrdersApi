using Domain.Entity;
using Domain.Models.CustomerModels;

namespace Application.Interfaces
{
  public interface ICustomerService : IServiceCrud<Customer, CustomerRequestModel, CustomerResponseModel>
  {
  }
}
