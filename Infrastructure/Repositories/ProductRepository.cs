using Infra.Repositories.GenericRepository;
using Infraestructure.Context;

namespace Infrastructure.Repositories
{
  public class ProductRepository : GenericRepository<Domain.Entity.Product>
  {
    public ProductRepository(MainContext dbContext) : base(dbContext)
    {

    }
  }
}
