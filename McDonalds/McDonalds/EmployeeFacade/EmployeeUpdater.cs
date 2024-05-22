using DataAccess;

namespace McDonalds.EmployeeFacade;

public class EmployeeUpdater
{
    private readonly McDonaldsDbContext _context;
    
    public EmployeeUpdater(McDonaldsDbContext context)
    {
        _context = context;
    }
    
    public void UpdateEmployee(Employee employee)
    {
        var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);

        if (existingEmployee != null)
        {
            existingEmployee.FullName = employee.FullName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Role = employee.Role;
            _context.Employees.Update(existingEmployee);
            _context.SaveChanges();
        }
    }
}