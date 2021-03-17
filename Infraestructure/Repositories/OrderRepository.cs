using Infra.Repositories.GenericRepository;
using Infraestructure.Context;

namespace Domain.RepositoryContracts
{
  public class OrderRepository : GenericRepository<Domain.Entity.Order>
  {
    public OrderRepository(MainContext dbContext) : base(dbContext)
    {

    }
  }
}
