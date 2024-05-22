namespace McDonalds.CurrencyStrageries;

public class USDtoGRNConversionStrategy : IPriceConversionStrategy
{
    public decimal Convert(decimal price)
    {
        return price * 38m;
    }
}