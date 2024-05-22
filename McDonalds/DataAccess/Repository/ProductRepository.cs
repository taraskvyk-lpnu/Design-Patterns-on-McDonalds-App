using DataAccess.Repository.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class ProductRepository<T> : IProductRepository<T> where T : Product 
{
    private readonly McDonaldsDbContext _context;

    public ProductRepository(McDonaldsDbContext context)
    {
        _context = context;
        Products = _context.Set<T>();
    }
    
    public DbSet<T> Products { get; private set; }
    
    public async Task<IEnumerable<T>> GetAllAsync(/*int page = 1, int itemsPerPage = 4,*/int categoryId = 0)
    {
        var products = Products.AsQueryable();

        if (categoryId > 0)
        {
            products = products.Where(p => p.CategoryId == categoryId);
        }

        return products;
        //return await products.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToListAsync();
    }

    public int GetProductNumberByCategoryId(int categoryId)
    {
        var products = Products.AsQueryable();

        if (categoryId < 1)
        {
            return products.Count();    
        }
        
        return products.Count(p => p.CategoryId == categoryId);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var product = await Products.FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task AddAsync(T product)
    {
        await Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveByIdAsync(int id)
    {
        var productToDelete = await Products.FirstOrDefaultAsync(p => p.Id == id);

        if (productToDelete != null)
        {
            Products.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<T?> UpdateAsync(T product)
    {
        var productToUpdate = await Products.FirstOrDefaultAsync(p => p.Id == product.Id);

        if (productToUpdate != null)
        {
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.ImageUrl = product.ImageUrl;
            await _context.SaveChangesAsync();

            return product;
        }
        
        return null;
    }
}