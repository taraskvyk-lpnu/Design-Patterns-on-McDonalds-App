namespace McDonalds.CurrencyStrageries;

public interface ICurrencyContext
{
    void SetStrategy(IPriceConversionStrategy strategy);
    decimal ConvertPrice(decimal price);
}