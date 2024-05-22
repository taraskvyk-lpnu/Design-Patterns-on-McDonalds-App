using Domain.Entites;
using McDonalds.EmployeeFacade;

namespace Domain;

public class Order
{
    public int OrderNumber { get; set; }
    public List<Burger> Burgers { get; set; }
    public List<Drink> Drinks { get; set; }
    public string Description { get; set; }
}