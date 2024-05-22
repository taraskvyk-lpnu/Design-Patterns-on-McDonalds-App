using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public class Burger : Product
{
    public List<string>? Ingredients { get; set; }
    public int Calories { get; set; }
    
    public Burger(string name, decimal price, int categoryId, int calories, List<string> ingredients) : base()
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        Ingredients = ingredients;
        Calories = calories;
        PriceUSD = Price;
    }
}