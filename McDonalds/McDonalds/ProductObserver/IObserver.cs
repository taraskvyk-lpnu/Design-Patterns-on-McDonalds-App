using McDonalds.CurrencyStrageries;

namespace McDonalds;

public interface IObserver
{
    void ConvertPrice(ICurrencyContext currencyContext);
}