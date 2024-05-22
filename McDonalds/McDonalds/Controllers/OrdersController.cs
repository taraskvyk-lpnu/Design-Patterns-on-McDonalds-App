using DataAccess;
using Domain;
using Domain.Entites;
using McDonalds.EmployeeFacade;
using McDonalds.Models;
using McDonalds.Models.Employees;
using McDonalds.OrderFactory;
using Microsoft.AspNetCore.Mvc;

namespace McDonalds.Controllers;

public class OrdersController : Controller
{
    private readonly McDonaldsDbContext _context;

    public OrdersController()
    {
        _context = McDonaldsDbContext.Context;  
    }
    public IActionResult Index()
    {
        return RedirectToAction("CreateOrders");
    }
    
    [HttpGet]
    [Route("orders")]
    public IActionResult CreateOrders(string difficulty = "LowDifficulty")
    {
        OrderFactory.OrderFactory factory = GetFactoryByDifficulty(difficulty);
        var orders = new List<Order>();
        
        for (int i = 0; i < 5; i++)
        {
            var order = CreateSingleOrder(factory);
            ProcessOrder(order);
            orders.Add(order);
        }
        
        return View("Index", orders);
    }

    private Order CreateSingleOrder(OrderFactory.OrderFactory factory)
    {
        List<Burger> burgerOrder = factory.CreateBurgers();
        List<Drink> drinkOrder = factory.CreateDrinks();
        
        var order = new Order
        {
            OrderNumber = new Random().Next(1, 1000),
            Burgers = burgerOrder,
            Drinks = drinkOrder,
            Description = string.Empty
        };

        return order;
    }
    private void ProcessOrder(Order order)
    {
        var mediator = new OrderMediator.OrderMediator();
        var cook = new Cook(GetFreeWorker(EmployeeRole.Cook), mediator);
        var cashier = new Cashier(GetFreeWorker(EmployeeRole.Cashier), mediator);
        
        mediator.AddWorker(cashier);
        mediator.AddWorker(cook);
        
        mediator.HandleOrder(order, cashier);
        mediator.HandleOrder(order, cook);
    }
    
    private string GetFreeWorker(EmployeeRole role)
    {
        var employeesNumber = _context.Employees.Count(e => e.Role == role);
        var randomNumber = new Random().Next(1, employeesNumber + 1);
        
        return _context.Employees.Where(e => e.Role == role)
            .Skip(randomNumber - 1)
            .Take(1)
            .Select(e => e.FullName)
            .FirstOrDefault() ?? string.Empty;
    }
    
    private OrderFactory.OrderFactory GetFactoryByDifficulty(string difficulty)
    {
        OrderFactory.OrderFactory factory;
            
        if (difficulty == "LowDifficulty")
            factory = new LowDifficultyFactory();
        else if (difficulty == "MediumDifficulty")
            factory = new MediumDifficultyFactory();
        else if (difficulty == "HardDifficulty")
            factory = new HardDifficultyFactory();
        else
            factory = new LowDifficultyFactory();

        ViewBag.Difficulty = difficulty;
        return factory;
    }
}