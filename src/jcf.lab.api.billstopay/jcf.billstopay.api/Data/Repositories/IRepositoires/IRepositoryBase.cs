namespace jcf.billstopay.api.Data.Repositories.IRepositoires
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<T?> CreateAsync(T entity);
        T? Update(T entity);
    }
}
