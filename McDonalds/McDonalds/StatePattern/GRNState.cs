namespace McDonalds;

public class GRNState : CurrencyState    
{
    public override void ChangeState(CurrencyState newState)
    {
        _instance = newState;
    }
    
    public override decimal ConvertPrice(decimal price)
    {
        return price * 40m;
    }
}