using Domain;
using McDonalds.EmployeeFacade;
using Microsoft.AspNetCore.Mvc;

namespace McDonalds.Controllers;

public class EmployeesController : Controller
{
    private readonly EmployeeFacade.EmployeeFacade EmployeeFacade;
    
    public EmployeesController()
    {
        EmployeeFacade = new EmployeeFacade.EmployeeFacade();
    }
    
    public IActionResult Index()
    {
        return View(EmployeeFacade.GetAll());
    }
    
    [HttpGet]
    //[Route("Employees")]
    public IActionResult AddEmployee()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
        EmployeeFacade.AddEmployee(employee);
        return RedirectToAction("Index");
    }

    [HttpGet]
    //[Route("Employees/{id:int}")]
    public IActionResult EditEmployee(int id)
    {
        var employee = EmployeeFacade.GetAll().FirstOrDefault(e => e.Id == id);
        return View(employee);
    }
    
    [HttpPost]
    public IActionResult EditEmployee(Employee employee)
    {
        EmployeeFacade.UpdateEmployee(employee);
        return RedirectToAction("Index");
    }

    public IActionResult RemoveEmployee(int id)
    {
        EmployeeFacade.RemoveEmployee(id);
        return RedirectToAction("Index");
    }
}