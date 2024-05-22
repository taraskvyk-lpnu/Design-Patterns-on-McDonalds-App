using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.Lightweight;

namespace McDonalds.MacMenuBuilder;

public class HamburgerMacMenuBuilder : MacMenuBuilder
{
    public HamburgerMacMenuBuilder()
    {
        this.Reset();
    }
    
    public override void BuildBurger()
    {
        var burger = new Hamburger();
        burger.ImageUrl = ImageFactory.GetImageUrl(typeof(Hamburger));
        _products.Add(burger);
    }

    public override void BuildDrink()
    {
        var drink = new Sprite();
        drink.ImageUrl = ImageFactory.GetImageUrl(typeof(Sprite));
        _products.Add(drink);
    }
    
    public override void BuildSideDish()
    {
        var side = new DeepFries();
        side.ImageUrl = ImageFactory.GetImageUrl(typeof(DeepFries));
        _products.Add(side);
    }

    public override List<Product> GetMacMenu() =>_products;
    
    private void Reset() => _products = new List<Product>();
}