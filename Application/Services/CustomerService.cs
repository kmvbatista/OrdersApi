using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DomainNotifications;
using Domain.Models.Customer;
using Domain.RepositoryContracts;

namespace Application.Services
{
  public class CustomerService : ICustomerService
  {
    private ICustomerRepository _customerRepository;
    private INotificationService _notificationService;

    public CustomerService(ICustomerRepository customerRepository, INotificationService notificationService)
    {
      _customerRepository = customerRepository;
      _notificationService = notificationService;
    }
    public Task Create(CustomerRequestModel request)
    {
      throw new NotImplementedException();
    }

    public Task Deactivate(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CustomerResponseModel>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<CustomerResponseModel> GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task Update(Guid id, CustomerRequestModel request)
    {
      throw new NotImplementedException();
    }

    public Task ValidateEntityExistence(Guid entityId)
    {
      throw new NotImplementedException();
    }
  }
}