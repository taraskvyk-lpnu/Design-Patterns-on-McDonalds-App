using Domain.Entites;
using McDonalds.CurrencyStrageries;

namespace McDonalds;

public class ProductObserver : IObserver
{
    private Product _product;

    public ProductObserver(Product product)
    {
        _product = product;
    }

    public void ConvertPrice(ICurrencyContext currencyContext)
    {
        _product.Price = currencyContext.ConvertPrice(_product.PriceUSD);
    }
}