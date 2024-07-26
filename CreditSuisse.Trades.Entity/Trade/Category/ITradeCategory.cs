namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    public interface ITradeCategory
    {
        public string Name { get; }
        public bool IsMatch(ITrade trade);
    }
}
