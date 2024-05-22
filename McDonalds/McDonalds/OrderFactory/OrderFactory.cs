using Domain.Entites;

namespace McDonalds.OrderFactory;

public abstract class OrderFactory
{
    protected List<Type> burgerTypes;
    protected List<Type> drinkTypes;
    
    public abstract List<Burger> CreateBurgers();
    public abstract List<Drink> CreateDrinks();
}