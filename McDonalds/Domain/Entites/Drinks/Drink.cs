namespace Domain.Entites;

public class Drink : Product
{
    public int Calories { get; set; }
    public int Milliliters { get; set; }

    public Drink(string name, decimal price, int categoryId, int calories, int milliliters)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Calories = calories;
        Milliliters = milliliters;
        PriceUSD = Price;
    }
}