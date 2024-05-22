using Domain.Entites;

namespace DataAccess.Repository.Interfaces;

public interface ICategoryRepository
{
    public IQueryable<Category> Categories { get; }
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task RemoveByIdAsync(int id);
    Task<Category?> UpdateAsync(Category category);
}