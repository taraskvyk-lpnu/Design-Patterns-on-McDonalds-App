namespace McDonalds.CurrencyStrageries;

public class USDtoEuroConversionStrategy : IPriceConversionStrategy
{
    public decimal Convert(decimal price)
    {
        return price * 1.2m;
    }
}