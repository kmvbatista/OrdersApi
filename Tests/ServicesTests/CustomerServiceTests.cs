using System;
using Domain.RepositoryContracts;
using Xunit;
using NSubstitute;
using Domain.DomainNotifications;
using Application.Interfaces;
using Application.Services;
using Domain.Models.Customer;
using Domain.Enums;
using Domain.Entity;
using Tests.Builders;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests
{
  public class CustomerServiceTests
  {
    private ICustomerRepository _customerRepository;
    private INotificationService _notificationService;

    private ICustomerService _customerService;

    public CustomerServiceTests()
    {
      _customerRepository = Substitute.For<ICustomerRepository>();
      _notificationService = Substitute.For<INotificationService>();
      _customerService = new CustomerService(_customerRepository, _notificationService);
    }

    [Fact]
    public void ShouldSaveNewCustomer()
    {
      //arrange
      var customerRequestModel = GetCustomerRequestModelExample();

      //action
      _customerService.Create(customerRequestModel);

      //assert
      _customerRepository.Received(1)
      .Create(Arg.Is<Customer>(c => c.Name == "Kennedy"
                                    && c.Document.ToString() == customerRequestModel.Document
                                    && c.Document.Type == customerRequestModel.DocumentType));
    }

    [Fact]
    public async Task ShouldUpdateCustomer()
    {
      //arrange
      var customerRequestModel = GetCustomerRequestModelExample();
      Customer customerToUpdate = new CustomerBuilder().WithName("Kennedy B")
        .WithDocument(DocumentType.CPF, customerRequestModel.Document.ToString())
        .WithId(customerRequestModel.Id).Construct();
      _customerRepository.GetById(customerRequestModel.Id).Returns(customerToUpdate);

      //act
      await _customerService.Update(customerRequestModel.Id, customerRequestModel);

      //assert
      await _customerRepository.Received(1)
      .Update(Arg.Is<Customer>(c => c.Document.ToString() == customerRequestModel.Document
                                    && c.IsActive == true
                                    && c.Name == customerRequestModel.Name));
    }

    [Fact]
    public async Task ShouldDeactivateCustomer()
    {
      //arrange
      var customerRequestModel = GetCustomerRequestModelExample();
      Customer customerToUpdate = new CustomerBuilder().WithName("Kennedy B")
        .WithDocument(DocumentType.CPF, customerRequestModel.Document.ToString())
        .WithId(customerRequestModel.Id).Construct();

      //act
      await _customerService.Deactivate(customerRequestModel.Id);

      //assert
      await _customerRepository.Received(1)
            .Deactivate(customerRequestModel.Id);
    }

    [Fact]
    public async Task ShouldgetCustomerbyId()
    {
      //arrange
      var customerId = Guid.NewGuid();
      var customerToReturn = new CustomerBuilder()
                      .WithId(customerId)
                      .WithName("Kennedy")
                      .WithDocument(DocumentType.CPF, "14832124676")
                      .Construct();
      _customerRepository.GetById(customerId).Returns(customerToReturn);

      //act
      CustomerResponseModel customerFound = await _customerService.GetById(customerId);

      //assert
      Assert.True(customerFound.Name == customerToReturn.Name
                  && customerFound.Document == customerToReturn.Document.ToString());
    }

    public async Task ShouldGetAllCustomers()
    {
      //arrange
      var customersToReturnFromRepo = GetCustomerListExample();
      _customerRepository.GetAll().Returns(customersToReturnFromRepo);

      //act
      IList<CustomerResponseModel> foundCustomers = await _customerService.GetAll();

      //assert
      Assert.True(foundCustomers[0].Name == customersToReturnFromRepo[0].Name
                  && foundCustomers[0].Document == customersToReturnFromRepo[0].Document.ToString());
    }

    private CustomerRequestModel GetCustomerRequestModelExample()
    {
      var model = new CustomerRequestModel()
      {
        Document = "14832124676",
        DocumentType = DocumentType.CPF,
        Name = "Kennedy Batista",
        Id = Guid.NewGuid()
      };
      return model;
    }

    private List<Customer> GetCustomerListExample()
    {
      var customer1 = new CustomerBuilder().WithName("João").WithDocument(DocumentType.CPF, "14832124676").Construct();
      var customer2 = new CustomerBuilder().WithName("Kennedy").WithDocument(DocumentType.CPF, "14832124676").Constuct();
      return new List<Customer>() { customer1, customer2 };
    }
  }
}
