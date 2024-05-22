using System.Reflection;
using Domain.Entites;
using McDonalds.Helpers;

namespace McDonalds.OrderFactory;

public class LowDifficultyFactory : OrderFactory
{
    private Random _random;
    public LowDifficultyFactory()
    {
        burgerTypes = DerivedTypesProvider.GetLowDifficultyTypes(typeof(Burger));
        drinkTypes = DerivedTypesProvider.GetLowDifficultyTypes(typeof(Drink));
        _random = new Random();
    }
    
    public override List<Burger> CreateBurgers()
    {
        int numberOfBurgers = _random.Next(1, 3);
        return ProductCreator.Create<Burger>(numberOfBurgers, burgerTypes);
    }

    public override List<Drink> CreateDrinks()
    {
        int numberOfDrinks = _random.Next(1, 3);
        return ProductCreator.Create<Drink>(numberOfDrinks, drinkTypes);
    }
}