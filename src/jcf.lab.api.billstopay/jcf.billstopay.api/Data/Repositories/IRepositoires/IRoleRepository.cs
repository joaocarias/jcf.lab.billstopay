using jcf.billstopay.api.Models;

namespace jcf.billstopay.api.Data.Repositories.IRepositoires;

public interface IRoleRepository : IRepositoryBase<Role>
{
    Task<IEnumerable<Role>> GetAll();
    Task<Role?> GetByName(string name);
}

