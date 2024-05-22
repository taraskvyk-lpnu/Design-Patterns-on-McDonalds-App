using System.ComponentModel.DataAnnotations.Schema;
using McDonalds.EmployeeFacade;

namespace Domain;

[NotMapped]
public class McDonaldsDepartment
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    private static McDonaldsDepartment _mcDonaldsDepartment;

    private McDonaldsDepartment()
    {
        Name = "McDonalds №1";
        Country = "Ukraine";
        City = "Lviv";
        Address = "Chornovola";
    }
    
    static McDonaldsDepartment()
    {
        if (_mcDonaldsDepartment == null)
        {
            _mcDonaldsDepartment = new McDonaldsDepartment();
        }
    }
    
    public static McDonaldsDepartment GetInstance()
    {
        return _mcDonaldsDepartment;
    }
}