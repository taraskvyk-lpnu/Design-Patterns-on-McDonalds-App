namespace McDonalds.CurrencyStrageries;

public class CurrencyContext : ICurrencyContext
{
    private IPriceConversionStrategy _strategy;
    public CurrencyContext(IPriceConversionStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IPriceConversionStrategy strategy)
    {
        _strategy= strategy;
    }

    public decimal ConvertPrice(decimal price)
    {
        return _strategy.Convert(price);
    }
}