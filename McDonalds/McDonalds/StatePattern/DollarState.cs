namespace McDonalds;

public class DollarState : CurrencyState    
{
    public override void ChangeState(CurrencyState newState)
    {
        _instance = newState;
    }
    
    public override decimal ConvertPrice(decimal price)
    {
        return price * 1.2m;
    }
}