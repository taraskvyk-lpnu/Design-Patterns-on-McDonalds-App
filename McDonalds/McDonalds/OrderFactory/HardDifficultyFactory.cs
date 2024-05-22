using Domain.Entites;

namespace McDonalds.OrderFactory;

public class HardDifficultyFactory : OrderFactory
{
    private Random _random;
    public HardDifficultyFactory()
    {
        burgerTypes = DerivedTypesProvider.GetHardDifficultyTypes(typeof(Burger));
        drinkTypes = DerivedTypesProvider.GetHardDifficultyTypes(typeof(Drink));
        _random = new Random();
    }
    
    public override List<Burger> CreateBurgers()
    {
        int numberOfBurgers = _random.Next(1, 7);
        return ProductCreator.Create<Burger>(numberOfBurgers, burgerTypes);
    }

    public override List<Drink> CreateDrinks()
    {
        int numberOfDrinks = _random.Next(1, 7);
        return ProductCreator.Create<Drink>(numberOfDrinks, drinkTypes);
    }
}