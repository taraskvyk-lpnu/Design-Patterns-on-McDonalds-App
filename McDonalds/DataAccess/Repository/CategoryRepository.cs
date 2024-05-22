using DataAccess.Repository.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly McDonaldsDbContext context;
    
    public CategoryRepository(McDonaldsDbContext context)
    {
        this.context = context;
        Categories = this.context.Categories;
        //context = McDonaldsDbContext.Instance(options);
        //Categories = context.Categories;
    }
    
    public IQueryable<Category> Categories { get; private set; }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await Categories.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Category category)
    {
        await context.Categories.AddAsync(category);
    }

    public async Task RemoveByIdAsync(int id)
    {
        var categoryToDelete = await Categories.FirstOrDefaultAsync(p => p.Id == id);

        if (categoryToDelete != null)
        {
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Category?> UpdateAsync(Category category)
    {
        var categoryToUpdate = await context.Categories.FirstOrDefaultAsync(p => p.Id == category.Id);

        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            await context.SaveChangesAsync();

            return category;
        }
        
        return null;
    }
}