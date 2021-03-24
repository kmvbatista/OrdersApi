using Domain.Entity;
using Domain.RepositoryContracts;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories.GenericRepository
{
  public abstract class GenericRepository<TEntity>
      : IGenericRepository<TEntity> where TEntity : BaseEntity
  {
    protected readonly MainContext _dbContext;

    public GenericRepository(MainContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task Create(TEntity entity)
    {
      await _dbContext.Set<TEntity>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task Deactivate(Guid id)
    {
      var entity = await GetById(id);
      entity.Deactivate();
      await Update(entity);
    }

    public async Task<IList<TEntity>> GetAll()
    {
      return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
      return await _dbContext.Set<TEntity>()
          .AsNoTracking()
          .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Update(TEntity entity)
    {
      _dbContext.Set<TEntity>().Update(entity);
      await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ValidateEntityExistence(Guid entityId)
    {
      bool entityExists = await _dbContext.Set<TEntity>().AnyAsync(x => x.Id == entityId);
      return entityExists;
    }
  }
}
