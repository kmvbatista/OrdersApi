using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Domain.Utils;
using Domain.Models;

namespace Application.ServicesContracts
{
  public interface IServiceCrud<TEntity, TRequestModel, TResponseModel>
                                      where TEntity : Domain.Entity.BaseEntity
                                    where TRequestModel : IRequestModel
                                    where TResponseModel : IResponseModel
  {
    Task Create(TRequestModel request);
    Task Update(Guid id, TRequestModel request);
    Task Deactivate(Guid id);
    Task<TResponseModel> GetById(Guid id);
    Task<IEnumerable<TResponseModel>> GetAll();
    TResponseModel MapCustomerToResponseModel(TEntity customer);
    TEntity MapCustomerFromRequestModel(TRequestModel customer);
  }
}