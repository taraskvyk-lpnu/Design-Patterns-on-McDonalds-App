using Domain;
using McDonalds.OrderMediator;
namespace McDonalds;

public abstract class Worker
{
    protected IOrderMediator mediator;
    public string Name { get; }

    public Worker(string name, IOrderMediator mediator)
    {
        this.Name = name;
        this.mediator = mediator;
    }

    public abstract void ProcessOrder(Order order);
}