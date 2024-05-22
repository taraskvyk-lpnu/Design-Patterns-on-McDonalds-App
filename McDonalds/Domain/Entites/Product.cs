using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal PriceUSD { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}