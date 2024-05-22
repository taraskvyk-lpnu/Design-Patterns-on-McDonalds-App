using DataAccess;

namespace McDonalds.EmployeeFacade;

public class EmployeeFacade
{
    private readonly McDonaldsDbContext _context;
    private EmployeeAdder adder;
    private EmployeeUpdater updater;
    private EmployeeRemover remover;
    
    public EmployeeFacade()
    {
        _context = McDonaldsDbContext.Context;
        adder = new EmployeeAdder(_context);
        updater = new EmployeeUpdater(_context);
        remover = new EmployeeRemover(_context);
    }

    public void AddEmployee(Employee employee)
    {
        adder.AddEmployee(employee);
    }

    public void UpdateEmployee(Employee employee)
    {
        updater.UpdateEmployee(employee);
    }

    public void RemoveEmployee(int id)
    {
        remover.RemoveEmployee(id);
    }

    public List<Employee> GetAll()
    {
        return _context.Employees.ToList();
    }
}