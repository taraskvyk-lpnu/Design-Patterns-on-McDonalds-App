namespace McDonalds;

public class EuroState : CurrencyState    
{
    public override void ChangeState(CurrencyState newState)
    {
        _instance = newState;
    }
    
    public override decimal ConvertPrice(decimal price)
    {
        return price * 2m;
    }
}