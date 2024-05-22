using DataAccess.Repository.Interfaces;
using Domain.Entites;
using McDonalds.Helpers;

namespace McDonalds.MenuDecorators;

public class MenuDrinkDecorator : IMenuDecorator
{
    public Menu _menu;
    public int CategoryId { get; private set; }
    private readonly IProductRepository<Drink> _repository;

    public MenuDrinkDecorator(Menu menu, int categoryId = 0)
    {
        _menu = menu;
        CategoryId = categoryId;
        _repository = RepositoryProvider.GetDrinksRepository();
    }

    public async Task AddProductsAsync()
    {
        var drinks = await _repository.GetAllAsync(CategoryId);
        _menu.AddProductRange(drinks.Cast<Product>().ToList());
    }
}