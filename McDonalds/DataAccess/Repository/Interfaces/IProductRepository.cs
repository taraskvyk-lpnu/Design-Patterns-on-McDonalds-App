using Domain.Entites;

namespace DataAccess.Repository.Interfaces;

public interface IProductRepository<T> where T : Product
{
    Task<IEnumerable<T>> GetAllAsync(/*int page = 1, int itemsPerPage = 4,*/ int categoryId = 0);
    public int GetProductNumberByCategoryId(int categoryId);
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T product);
    Task RemoveByIdAsync(int id);
    Task<T?> UpdateAsync(T product);
}