using CreditSuisse.Trades.Util;

namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    public class NotThatHighRisk : ITradeCategory
    {
        public string Name { get => Constants.Category.NOTTHATHIGHRISK; }

        private const double _limitValue = 1_000_000;

        public NotThatHighRisk()
        {
        }

        public bool IsMatch(ITrade trade)
        {
            return trade.ClientSector == Constants.ClientSector.PRIVATE && trade.Value < _limitValue;
        }
    }
}
