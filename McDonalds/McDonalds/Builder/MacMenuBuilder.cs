using Domain.Entites;

namespace McDonalds.MacMenuBuilder;

public abstract class MacMenuBuilder
{
    protected List<Product> _products;
    public abstract void BuildBurger();
    public abstract void BuildDrink();
    public abstract void BuildSideDish();
    public abstract List<Product> GetMacMenu();
}