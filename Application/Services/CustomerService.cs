using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Customer;

namespace Application.Services {
  public class CustomerService : IServiceCrud<CustomerRequestModel, CustomerReponseModel>
  {
    public Task Create(CustomerRequestModel request)
    {
      throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CustomerReponseModel>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CustomerReponseModel> GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(Guid id, CustomerRequestModel request)
    {
      throw new NotImplementedException();
    }
  }
}