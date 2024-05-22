using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.Lightweight;

namespace McDonalds.MacMenuBuilder;

public class BigMacMenuBuilder : MacMenuBuilder
{
    public BigMacMenuBuilder()
    {
        this.Reset();
    }
    
    public override void BuildBurger()
    {
        var burger = new BigMacBurger();
        burger.ImageUrl = ImageFactory.GetImageUrl(burger.GetType());
        _products.Add(burger);
    }

    public override void BuildDrink()
    {
        var drink = new Coke();
        drink.ImageUrl = ImageFactory.GetImageUrl(typeof(Coke));
        _products.Add(drink);
    }
    
    public override void BuildSideDish()
    {
        var side = new FrenchFries();
        side.ImageUrl = ImageFactory.GetImageUrl(typeof(FrenchFries));
        _products.Add(side);
    }
    
    public override List<Product> GetMacMenu()
    {
        return _products;
    }
    
    private void Reset() =>_products = new List<Product>();
}