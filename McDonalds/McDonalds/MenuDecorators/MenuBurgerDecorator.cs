using DataAccess.Repository.Interfaces;
using Domain.Entites;
using McDonalds.Helpers;

namespace McDonalds.MenuDecorators;

public class MenuBurgerDecorator : IMenuDecorator
{
    public Menu _menu;
    public int CategoryId { get; private set; }
    private readonly IProductRepository<Burger> _repository;

    public MenuBurgerDecorator(Menu menu, int categoryId = 0)
    {
        _menu = menu;
        CategoryId = categoryId;
        _repository = RepositoryProvider.GetBurgersRepository();
    }

    public async Task AddProductsAsync()
    {
        var burgers = await _repository.GetAllAsync(CategoryId);
        _menu.AddProductRange(burgers.Cast<Product>().ToList());
    }
}