using System.Text.Json;
using DataAccess.Repository.Interfaces;
using Domain.Entites;
using McDonalds.CurrencyStrageries;
using McDonalds.Helpers;
using McDonalds.MenuDecorators;
using McDonalds.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McDonalds.Views.Home;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)] public List<string> CurrentCategoryIds { get; set; }
    [BindProperty(SupportsGet = true)] public int ItemsPerPage { get; set; } = 10;
    [BindProperty(SupportsGet = true)] public int Page { get; set; } = 1;
    public List<Product> Products { get; set; }
    public PaginatedList<Product> PaginatedProducts { get; set; }
    public List<Category> Categories { get; set; }
    public static Menu Menu { get; private set; } = new Menu();
    private Dictionary<string, Func<Menu, int, IMenuDecorator>> categoryDecorators;
    
    public async Task<IActionResult> OnGet()
    {
        await Menu.LoadCategories();
        CurrentCategoryIds = Menu.GetCategoryIds().Select(id => id.ToString()).ToList();
        Categories = Menu.Categories;
        
        var categoriesJson = JsonSerializer.Serialize(Menu.Categories);
        HttpContext.Session.SetString("Categories", categoriesJson);
        
        InitializeCategoryDictionary();
        await FillProducts();
        return Page();
    }
    
    public void InitializeCategoryDictionary()
    {
        var categoriesJson = HttpContext.Session.GetString("Categories");
        Categories = JsonSerializer.Deserialize<List<Category>>(categoriesJson);
        
        CategoryDecoratorDictionaryProvider.InitializeCategoryDecoratorDictionary(Categories);
        categoryDecorators = CategoryDecoratorDictionaryProvider.categoryDecorators;
    }

    public async Task FillProducts()
    {
        Menu.Products = new List<Product>();
        var selectedCategories = Menu.Categories
            .Where(c => CurrentCategoryIds.Contains(c.Id.ToString()));
    
        foreach (var category in selectedCategories)
        {
            if (categoryDecorators.TryGetValue(category.Name, out var decoratorFactory))
            {
                var menuDecorator = decoratorFactory.Invoke(Menu, category.Id);
                await menuDecorator.AddProductsAsync();
            }
        }

        Products = Menu.GetProducts();

        PaginatedProducts = new PaginatedList<Product>(
            Products, 
            Menu.GetProducts().Count,
            ItemsPerPage,
            Page);
        
        HttpContext.Session.SetString("CurrentProducts", 
            JsonSerializer.Serialize(Products));

        ChangeCurrency();
    }

    public IActionResult ChangeCurrency()
    {
        List<IObserver> observers = Products
            .Select(p => (IObserver)new ProductObserver(p)).ToList();
        
        ICurrencyContext currencyContext = new CurrencyContext(GetCurrencyStrategy());
        ObserverContext observerContext = new ObserverContext(observers, currencyContext);
        observerContext.NotifyObservers();
        
        return Page();
    }
    
    private IPriceConversionStrategy GetCurrencyStrategy()
    {
        var currency = HttpContext.Session.GetString("Currency");
        return currency switch
        {
            "Pounds" => new USDtoPoundConversionStrategy(),
            "Euro" => new USDtoEuroConversionStrategy(),
            "GRN" => new USDtoGRNConversionStrategy(),
            _ => new USDConversionStrategy()
        };
    }
    
    public async Task<IActionResult> OnPost(string[] categoryIds)
    {
        CurrentCategoryIds = categoryIds.ToList();
        if (Menu.Products != null)
        {
            Menu.ResetProducts();
        }
        
        InitializeCategoryDictionary();
        await FillProducts();
        
        return Page();
    }
}