using jcf.billstopay.api.Data.Contexts;
using jcf.billstopay.api.Data.Repositories.IRepositoires;
using jcf.billstopay.api.Models;
using Microsoft.EntityFrameworkCore;

namespace jcf.billstopay.api.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<RoleRepository> _logger;

    public RoleRepository(AppDbContext appDbContext, ILogger<RoleRepository> logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }

    public async Task<Role?> CreateAsync(Role entity)
    {
        try
        {
            await _appDbContext.Roles.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        try
        {
            return await _appDbContext.Roles.Where(_ => _.IsActive).AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Enumerable.Empty<Role>();
        }
    }

    public async Task<Role?> GetAsync(Guid id)
    {
        try
        {
            return await _appDbContext.Roles.Where(_ => _.Id.Equals(id)).AsNoTracking().SingleOrDefaultAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public Role? Update(Role entity)
    {
        try
        {           
            _appDbContext.Roles.Update(entity);
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
