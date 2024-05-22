namespace McDonalds.CurrencyStrageries;

public class USDtoPoundConversionStrategy : IPriceConversionStrategy
{
    public decimal Convert(decimal price)
    {
        return price * 1.26m;
    }
}