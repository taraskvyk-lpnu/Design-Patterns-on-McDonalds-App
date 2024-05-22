using DataAccess.Repository.Interfaces;
using Domain.Entites;
using McDonalds.Helpers;

namespace McDonalds.MenuDecorators;

public class Menu
{
    public List<Product> Products { get; set; }
    public List<Category> Categories { get; set; }
    private readonly ICategoryRepository _categoryRepository;
    
    public Menu()
    {
        Products = new List<Product>();
        _categoryRepository = RepositoryProvider.GetCategoryRepository();
    }

    public async Task LoadCategories()
    {
        Categories = (await _categoryRepository.GetAllAsync()).ToList();
    }

    public List<int> GetCategoryIds()
    {
        return Categories.Select(c => c.Id).ToList();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    
    public void AddProductRange(List<Product> products)
    {
        Products.AddRange(products);
    }
    
    public List<Product> GetProducts()
    {
        return Products;
    }
    
    public void ResetProducts()
    {
        Products.Clear();
    }
}
