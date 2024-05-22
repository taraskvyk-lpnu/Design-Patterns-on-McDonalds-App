using Domain;
using McDonalds.OrderMediator;

namespace McDonalds.Models.Employees;

public class Cook : Worker
{
    public Cook(string name, IOrderMediator mediator) : base(name, mediator) { }

    public override void ProcessOrder(Order order)
    {
        order.Description += $"Cook: {Name}\n";
    }
}