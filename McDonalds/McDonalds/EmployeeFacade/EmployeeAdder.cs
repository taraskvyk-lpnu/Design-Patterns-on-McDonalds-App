using DataAccess;

namespace McDonalds.EmployeeFacade;

public class EmployeeAdder
{
    private readonly McDonaldsDbContext _context;
    public EmployeeAdder(McDonaldsDbContext context)
    {
        _context = context;
    }
    
    public void AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        Console.WriteLine($"Додаємо працівника {employee.FullName} до бази даних.");
    }
}