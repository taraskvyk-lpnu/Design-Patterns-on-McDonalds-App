using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.Lightweight;
using Microsoft.AspNetCore.Components.Endpoints;

namespace McDonalds.MacMenuBuilder;

public class RoyalCheeseMenuBuilder : MacMenuBuilder
{
    public RoyalCheeseMenuBuilder()
    {
        this.Reset();
    }
    
    public override void BuildBurger()
    {
        var burger = new RoyalBurger();
        burger.ImageUrl = ImageFactory.GetImageUrl(typeof(RoyalBurger));
        _products.Add(burger);
    }

    public override void BuildDrink()
    {
        var drink = new Fanta();
        drink.ImageUrl = ImageFactory.GetImageUrl(typeof(Fanta));
        _products.Add(drink);
    }
    
    public override void BuildSideDish()
    {
        var side = new DeepFries();
        side.ImageUrl = ImageFactory.GetImageUrl(typeof(DeepFries));
        _products.Add(side);
    }
    
    public override List<Product> GetMacMenu() => _products;
    
    private void Reset() => _products = new List<Product>();
}