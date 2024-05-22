using Domain;

namespace McDonalds.OrderMediator;

public class OrderMediator : IOrderMediator
{
    private List<Worker> _workers = new List<Worker>();

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
    }

    public void HandleOrder(Order order, Worker worker)
    {
        if (_workers.Contains(worker))
        {
            worker.ProcessOrder(order);
        }
        else
        {
            Console.WriteLine($"Співробітник '{worker.Name}' не знайдений.");
        }
    }
}