using jcf.billstopay.api.Data.Contexts;
using jcf.billstopay.api.Data.Repositories.IRepositoires;
using jcf.billstopay.api.Models;
using Microsoft.EntityFrameworkCore;

namespace jcf.billstopay.api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext appDbContext, ILogger<UserRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<User?> AuthenticateAsync(string userName, string password)
        {
            try
            {
                return await _appDbContext.Users.Where(_ => _.UserName.Equals(userName) && _.Password.Equals(password) && _.IsActive).AsNoTracking().SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<User?> CreateAsync(User entity)
        {
            try
            {
                await _appDbContext.Users.AddAsync(entity);
                await _appDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<User?> GetAsync(Guid id)
        {
            try
            {
                return await _appDbContext.Users.Where(_ => _.Id.Equals(id)).AsNoTracking().SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public User? Update(User entity)
        {
            try
            {
                _appDbContext.Users.Update(entity);
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
