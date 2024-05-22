using DataAccess;
using Domain;

namespace McDonalds.EmployeeFacade;

public class EmployeeRemover
{
    private readonly McDonaldsDbContext _context;

    public EmployeeRemover(McDonaldsDbContext context)
    {
        _context = context;
    }
    
    public void RemoveEmployee(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            Console.WriteLine($"Видаляємо працівника з ID={id} з бази даних.");
        }
    }
}