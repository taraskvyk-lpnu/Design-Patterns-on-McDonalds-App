using DataAccess.Repository.Interfaces;
using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.Helpers;

namespace McDonalds.MenuDecorators;

public class MenuSideDishesDecorator : IMenuDecorator
{
    public Menu _menu;
    public int CategoryId { get; private set; }
    private readonly IProductRepository<SideDish> _repository;

    public MenuSideDishesDecorator(Menu menu, int categoryId = 0)
    {
        _menu = menu;
        CategoryId = categoryId;
        _repository = RepositoryProvider.GetSideDishesRepository();
    }

    public async Task AddProductsAsync()
    {
        var sideDishes = await _repository.GetAllAsync(CategoryId);
        _menu.AddProductRange(sideDishes.Cast<Product>().ToList());
    }
}