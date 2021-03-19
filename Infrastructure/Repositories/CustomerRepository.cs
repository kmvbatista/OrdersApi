
using Infra.Repositories.GenericRepository;
using Infraestructure.Context;

namespace Infrastructure.Repositories
{
  public class CustomerRepository : GenericRepository<Domain.Entity.Customer>
  {
    public CustomerRepository(MainContext dbContext) : base(dbContext)
    {

    }
  }
}
