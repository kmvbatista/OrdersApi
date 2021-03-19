using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IServiceCrud<TRequestModel, TResponseModel> {
        Task Create(TRequestModel request);
        Task Update(Guid id, TRequestModel request);
        Task Delete(Guid id);
        Task<TResponseModel> GetById(Guid id);
        Task<IList<TResponseModel>> GetAll();
        Task ValidateEntityExistence(Guid entityId);
    }
}