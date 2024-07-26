namespace CreditSuisse.Trades.Infrastructure.Trade
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
    }
}
