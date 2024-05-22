using Domain;
using McDonalds.EmployeeFacade;

namespace McDonalds.OrderMediator;

public interface IOrderMediator
{
    void AddWorker(Worker worker);
    void HandleOrder(Order order, Worker worker);
}