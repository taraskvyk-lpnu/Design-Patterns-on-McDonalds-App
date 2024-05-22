using McDonalds.Models;

namespace McDonalds.EmployeeFacade;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public EmployeeRole Role { get; set; }

    public Employee()
    {
        
    }
    public Employee(string fullName, string email, EmployeeRole role, int id = 0)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        Role = role;
    }
}