namespace jcf.billstopay.api.Data.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T?> GeyAsync(T id);  
        Task<T?> CreateAsync(T entity);
        Task<T?> Update(T entity);         
    }
}
