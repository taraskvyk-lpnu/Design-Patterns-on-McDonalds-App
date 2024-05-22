using System.Reflection;
using Domain.Entites;
using McDonalds.MacMenuBuilder;
using McDonalds.OrderFactory;
using McDonalds.Views;
using Microsoft.AspNetCore.Mvc;

namespace McDonalds.Controllers;

public class MacMenuController : Controller
{
    // GET
    public IActionResult Index()
    {
        var builders = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "McDonalds.MacMenuBuilder")
            .Where(t => typeof(MacMenuBuilder.MacMenuBuilder).IsAssignableFrom(t))
            .Select(Activator.CreateInstance)
            .Cast<MacMenuBuilder.MacMenuBuilder>()
            .ToList();

        return View(builders);
    }
}