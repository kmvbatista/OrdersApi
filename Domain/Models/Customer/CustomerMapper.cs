using System;
using AutoMapper;
using Domain.Models.CustomerModels;
using Domain.Entity;
using Domain.Utils;

namespace Domain.Models.CustomerMappers
{
  public class CustomerMapper
                : BaseMapper<Customer, CustomerRequestModel, CustomerResponseModel>
  {
    public CustomerMapper()
    {
      _mapper = new MapperConfiguration(cfg =>
     {
       cfg.CreateMap<Customer, CustomerResponseModel>();
       cfg.CreateMap<CustomerRequestModel, Customer>();
     }).CreateMapper();
    }
  }
}