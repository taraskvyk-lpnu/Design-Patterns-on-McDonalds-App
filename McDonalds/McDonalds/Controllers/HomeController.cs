using System.Diagnostics;
using DataAccess.Repository.Interfaces;
using Domain;
using Domain.Entites;
using McDonalds.CurrencyStrageries;
using McDonalds.Helpers;
using Microsoft.AspNetCore.Mvc;
using McDonalds.Models;
using McDonalds.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace McDonalds.Controllers;

public class HomeController : Controller
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResult> Index()
    {
        _httpContextAccessor.HttpContext.Session.SetString("Currency", "USD");
        return RedirectToPage("/Home/Index");
    }
 
    public async Task<IActionResult> ChangeCurrency(string currency)
    {
        _httpContextAccessor.HttpContext.Session.SetString("Currency", currency);
        return RedirectToPage("/Home/Index");
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}