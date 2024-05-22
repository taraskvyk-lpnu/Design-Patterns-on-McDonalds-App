namespace McDonalds.CurrencyStrageries;

public class USDConversionStrategy : IPriceConversionStrategy
{
    public decimal Convert(decimal price)
    {
        return price;
    }
}