using Domain.Models.Customer;

namespace Application.Interfaces
{
  public interface ICustomerService : IServiceCrud<CustomerRequestModel, CustomerResponseModel>
  {
  }
}
