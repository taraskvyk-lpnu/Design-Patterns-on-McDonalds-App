using McDonalds.CurrencyStrageries;

namespace McDonalds;

public class ObserverContext
{
    private List<IObserver> _observers = new List<IObserver>();
    private ICurrencyContext _currencyContext;

    public ObserverContext(List<IObserver> observers, ICurrencyContext currencyContext)
    {
        _currencyContext = currencyContext;
        _observers = observers;
        NotifyObservers();
    }
    
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    
    public void SetState(ICurrencyContext currencyContext)
    {
        _currencyContext = currencyContext;
        NotifyObservers();
    }
    
    public void AttachRange(List<IObserver> observer)
    {
        _observers.AddRange(observer);
    }
    
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.ConvertPrice(_currencyContext);
        }
    }
}