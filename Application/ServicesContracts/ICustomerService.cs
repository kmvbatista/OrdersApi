using Domain.Entity;
using Domain.Models.CustomerModels;

namespace Application.ServicesContracts
{
  public interface ICustomerService : IServiceCrud<Customer, CustomerRequestModel, CustomerResponseModel>
  {
  }
}
