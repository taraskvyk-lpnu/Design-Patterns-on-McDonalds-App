using CurrencyState = McDonalds.CurrencyState;

namespace McDonalds;

public abstract class CurrencyState
{
    protected static CurrencyState _instance;

    static CurrencyState()
    {
        if (_instance == null)
        {
            _instance = new DollarState();
        }
    }
    protected CurrencyState() { }

    public static CurrencyState GetInstance()
    {
        return _instance;
    }

    public abstract void ChangeState(CurrencyState newState);
    public abstract decimal ConvertPrice(decimal price);
}