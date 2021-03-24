using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DomainNotifications;
using Domain.Entity;
using Domain.Models.CustomerMappers;
using Domain.Models.CustomerModels;
using Domain.RepositoryContracts;

namespace Application.Services
{
  public class CustomerService : ICustomerService
  {
    private ICustomerRepository _customerRepository;
    private INotificationService _notificationService;
    private CustomerMapper _customerMapper;

    public CustomerService(ICustomerRepository customerRepository, INotificationService notificationService)
    {
      _customerRepository = customerRepository;
      _notificationService = notificationService;
      _customerMapper = new CustomerMapper();
    }

    public async Task Create(CustomerRequestModel requestModel)
    {
      Customer customer = MapCustomerFromRequestModel(requestModel);
      if (!_notificationService.IsEntityValid(customer))
        return;
      await _customerRepository.Create(customer);
    }

    public async Task Deactivate(Guid id)
    {
      if (_notificationService.IsGuidValid(id))
        return;
      await _customerRepository.Deactivate(id);
    }

    public async Task<IEnumerable<CustomerResponseModel>> GetAll()
    {
      var customers = await _customerRepository.GetAll();
      var customersResponseModel = customers.Select(MapCustomerToResponseModel);
      return customersResponseModel;
    }

    public async Task<CustomerResponseModel> GetById(Guid id)
    {
      if (_notificationService.IsGuidValid(id))
        return null;
      var customer = await _customerRepository.GetById(id);
      return MapCustomerToResponseModel(customer);
    }

    public async Task Update(Guid id, CustomerRequestModel customerRequestModel)
    {
      if (!_notificationService.IsGuidValid(id))
        return;
      var customerToUpdate = await _customerRepository.GetById(id);
      customerToUpdate.Update(customerRequestModel);
      if (!_notificationService.IsEntityValid(customerToUpdate))
        return;
      await _customerRepository.Update(customerToUpdate);
    }

    public Customer MapCustomerFromRequestModel(CustomerRequestModel customer) =>
      _customerMapper.MapFromRequestModel(customer);

    public CustomerResponseModel MapCustomerToResponseModel(Customer customer) =>
      _customerMapper.MapToResponseModel(customer);

  }
}