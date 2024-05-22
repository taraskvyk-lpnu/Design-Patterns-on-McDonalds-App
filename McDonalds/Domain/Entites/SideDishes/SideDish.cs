namespace Domain.Entites.SideDishes;

public class SideDish : Product
{
    public SideDish(string name, decimal price, int categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        PriceUSD = Price;
    }
}