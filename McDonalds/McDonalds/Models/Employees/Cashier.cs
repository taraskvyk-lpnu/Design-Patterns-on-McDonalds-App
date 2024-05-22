using Domain;
using McDonalds.OrderMediator;

namespace McDonalds.EmployeeFacade;

public class Cashier : Worker
{
    public Cashier(string name, IOrderMediator mediator) : base(name, mediator) { }

    public override void ProcessOrder(Order order)
    {
        order.Description += $"Cashier: {Name}.\n";
    }
}