using Domain.Entites;
using McDonalds.MenuDecorators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McDonalds.Views;

public class MenuModel : PageModel
{
    public bool ShowMenu { get; private set; } = false;
    public List<Product> Products { get; private set; } = new List<Product>();
    public static Menu Menu { get; private set; } = new Menu();
        
    private Dictionary<string, Func<Menu, IMenuDecorator>> categoryDecorators = new Dictionary<string, Func<Menu, IMenuDecorator>>
    {
        ["burgers"] = (Menu menu) =>
        {
            Console.WriteLine(menu.GetHashCode());
            return new MenuBurgerDecorator(menu);
        },
        ["drinks"] = (Menu menu) => new MenuDrinkDecorator(menu),
        ["sidedishes"] = (Menu menu) => new MenuSideDishesDecorator(menu)
    };

    public void OnGet()
    {
        
    }

    public async Task OnPostAsync(string[] categories)
    {
        if (categories == null || categories.Length == 0)
        {
            ShowMenu = false;
            Products.Clear();
            return;
        }

        foreach (var category in categories)
        {
            if (categoryDecorators.TryGetValue(category, out var decoratorFactory))
            {
                var decorator = decoratorFactory.Invoke(Menu);
                Console.WriteLine(Menu.GetHashCode());
                await decorator.AddProductsAsync();
            }
        }

        ShowMenu = true;
        Products = Menu.GetProducts();
    }
}