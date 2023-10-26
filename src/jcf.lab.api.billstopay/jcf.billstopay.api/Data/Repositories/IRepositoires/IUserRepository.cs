using jcf.billstopay.api.Models;

namespace jcf.billstopay.api.Data.Repositories.IRepositoires
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> AuthenticateAsync(string userName, string password);
    }
}
