using Domain.Entites;

namespace McDonalds.OrderFactory;
public class MediumDifficultyFactory : OrderFactory
{
    private Random random = new Random();
    private readonly List<Type> burgerTypes;
    private readonly List<Type> drinkTypes;

    public MediumDifficultyFactory()
    {
        burgerTypes = DerivedTypesProvider.GetMediumDifficultyTypes(typeof(Burger));
        drinkTypes = DerivedTypesProvider.GetMediumDifficultyTypes(typeof(Drink));
    }
    
    public override List<Burger> CreateBurgers()
    {
        int numberOfBurgers = random.Next(1, 5);
        return ProductCreator.Create<Burger>(numberOfBurgers, burgerTypes);
    }

    public override List<Drink> CreateDrinks()
    {
        int numberOfDrinks = random.Next(1, 5);
        return ProductCreator.Create<Drink>(numberOfDrinks, drinkTypes);
    }
}
