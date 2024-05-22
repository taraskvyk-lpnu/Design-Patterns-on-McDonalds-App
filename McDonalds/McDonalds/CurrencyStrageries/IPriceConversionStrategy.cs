namespace McDonalds.CurrencyStrageries;

public interface IPriceConversionStrategy
{
    decimal Convert(decimal price);
}