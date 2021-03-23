using AutoMapper;
using Domain.Models;

namespace Domain.Utils
{
  public abstract class BaseMapper<TEntity, TRequestModel, TResponseModel>
                         where TEntity : Entity.BaseEntity
                         where TRequestModel : IRequestModel
                         where TResponseModel : IResponseModel
  {
    protected IMapper _mapper;

    public TResponseModel MapToResponseModel(TEntity modelToMap)
    {
      return _mapper.Map<TResponseModel>(modelToMap);
    }

    public TEntity MapFromRequestModel(TRequestModel modelToMap)
    {
      return _mapper.Map<TEntity>(modelToMap);
    }
  }
}
