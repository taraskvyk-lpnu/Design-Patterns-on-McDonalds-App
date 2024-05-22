using Domain.Entites;
using McDonalds.MenuDecorators;

namespace McDonalds.Helpers;

public class CategoryDecoratorDictionaryProvider
{
    public static Dictionary<string, Func<Menu, int, IMenuDecorator>> categoryDecorators;
    public static void InitializeCategoryDecoratorDictionary(List<Category> categories)
    {
        categoryDecorators = new Dictionary<string, Func<Menu, int, IMenuDecorator>>();

        foreach (var category in categories ?? new List<Category>())
        {
            if (category.Name.Contains("Burger"))
            {
                categoryDecorators.Add(category.Name,
                    (menu, categoryId) => new MenuBurgerDecorator(menu, category.Id));
            }
            else if (category.Name.Contains("Drink"))
            {
                categoryDecorators.Add(category.Name,
                    (menu, categoryId) => new MenuDrinkDecorator(menu, category.Id));
            }
            else if (category.Name.Contains("Side"))
            {
                categoryDecorators.Add(category.Name,
                    (menu, categoryId) => new MenuSideDishesDecorator(menu, category.Id));
            }
        }
    }
}