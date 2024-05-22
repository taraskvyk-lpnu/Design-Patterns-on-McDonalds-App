using Domain.Entites;
using Domain.Entites.SideDishes;
using McDonalds.EmployeeFacade;
using McDonalds.Lightweight;
using McDonalds.Models;

namespace DataAccess;

public class SeedData
{
    public static void Initialize(McDonaldsDbContext context)
    {
        // Look for any records.
        //context.Categories.RemoveRange(context.Categories.ToList());
        //context.Drinks.RemoveRange(context.Drinks.ToList());
        //context.Burger.RemoveRange(context.Burger.ToList());
        //context.SideDishes.RemoveRange(context.SideDishes.ToList());
        //context.Employees.RemoveRange(context.Employees.ToList());
        //context.Images.RemoveRange(context.Images.ToList());
        //context.SaveChanges();
        
        if (context.Categories.Any() || context.Burger.Any() || context.Drinks.Any())
        {
            return;
        }

        var employees = new List<Employee>
        {
            new Employee("John Smith", "john@example.com", EmployeeRole.Cashier),
            new Employee("Emma Johnson", "emma@example.com", EmployeeRole.Cashier),
            new Employee("Gabriel Snow", "gabi@example.com", EmployeeRole.Cook),
            new Employee("Michael Williams", "michael@example.com", EmployeeRole.Cook)
        };
        context.Employees.AddRange(employees);
        context.SaveChanges();
        
        var images = new List<Image>
        {
            new Image(typeof(BigMacBurger).Name, "images/big-mac.jpg"),
            new Image(typeof(Hamburger).Name, "images/hamburger.jpg"), 
            new Image(typeof(RoyalBurger).Name, "images/royal-cheese-burger.jpg"),
            new Image(typeof(Coke).Name, "images/coke.jpg"),
            new Image(typeof(Fanta).Name, "images/fanta.jpg"),
            new Image(typeof(Sprite).Name, "images/sprite.jpg"),
            new Image(typeof(IceLate).Name, "images/ice-late.jpg"),
            new Image(typeof(Late).Name, "images/late.jpg"),
            new Image(typeof(FrenchFries).Name, "images/french-fries.jpg"),
            new Image(typeof(DeepFries).Name, "images/fries-deeps.jpg"),
        };
        context.Images.AddRange(images);
        context.SaveChanges();
        
        var categories = new List<Category>
        {
            new Category { Name = "Burger"},
            new Category { Name = "SodaDrink" },
            new Category { Name = "CoffeeDrink" },
            new Category { Name = "Side Dishes" }
        };
        context.Categories.AddRange(categories);
        context.SaveChanges();

        var burgers = new List<Burger>
        {
            new BigMacBurger { CategoryId = categories[0].Id },
            new RoyalBurger { CategoryId = categories[0].Id },
            new Hamburger { CategoryId = categories[0].Id }
        };
        
        burgers.ForEach(b => b.ImageUrl = ImageFactory.GetImageUrl(b.GetType()));
        context.Burger.AddRange(burgers);
        context.SaveChanges();

        var drinks = new List<Drink>
        {
            new Coke { CategoryId = categories[1].Id },
            new Fanta() { CategoryId = categories[1].Id },
            new Sprite { CategoryId = categories[1].Id },
            new Late { CategoryId = categories[2].Id },
            new IceLate() { CategoryId = categories[2].Id }
        };
        
        drinks.ForEach(d => d.ImageUrl = ImageFactory.GetImageUrl(d.GetType()));
        context.Drinks.AddRange(drinks);
        context.SaveChanges();
        
        var sideDishes = new List<SideDish>
        {
            new FrenchFries() { CategoryId = categories[3].Id },
            new DeepFries() { CategoryId = categories[3].Id }, 
        };
        
        sideDishes.ForEach(sd => sd.ImageUrl = ImageFactory.GetImageUrl(sd.GetType()));
        context.SideDishes.AddRange(sideDishes);
        context.SaveChanges();
    }
}