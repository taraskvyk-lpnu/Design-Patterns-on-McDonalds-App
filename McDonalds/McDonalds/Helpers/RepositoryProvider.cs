using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Domain.Entites;
using Domain.Entites.SideDishes;

namespace McDonalds.Helpers;

public class RepositoryProvider
{
    public static ICategoryRepository GetCategoryRepository()
    {
        return new CategoryRepository(McDonaldsDbContext.Context);
    }
    
    public static IProductRepository<Burger> GetBurgersRepository()
    {
        return new ProductRepository<Burger>(McDonaldsDbContext.Context);
    }
    
    public static IProductRepository<Drink> GetDrinksRepository()
    {
        return new ProductRepository<Drink>(McDonaldsDbContext.Context);
    }
    
    public static IProductRepository<SideDish> GetSideDishesRepository()
    {
        return new ProductRepository<SideDish>(McDonaldsDbContext.Context);
    }
}