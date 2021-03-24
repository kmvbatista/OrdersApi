using System;
using AutoMapper;
using Domain.Models.CustomerModels;
using Domain.Entity;
using Domain.Utils;
using Domain.ValueObjects;

namespace Domain.Models.CustomerMappers
{
  public class CustomerMapper
                : BaseMapper<Customer, CustomerRequestModel, CustomerResponseModel>
  {
    public BaseMapper<Customer, CustomerRequestModel, CustomerResponseModel> x;
    public CustomerMapper()
    {
      _mapper = new MapperConfiguration(cfg =>
     {
       cfg.CreateMap<Customer, CustomerResponseModel>()
          .ForMember(resModel => resModel.Document,
                              map => map.MapFrom(cust => cust.Document.ToString()))
          .ForMember(resModel => resModel.DocumentType,
                              map => map.MapFrom(cust => cust.Document.Type));

       cfg.CreateMap<CustomerRequestModel, Customer>()
          .ForMember(cust => cust.Document,
                              map => map.MapFrom(request =>
                                 new Document(request.Document, request.DocumentType)));
     }).CreateMapper();
    }
  }
}