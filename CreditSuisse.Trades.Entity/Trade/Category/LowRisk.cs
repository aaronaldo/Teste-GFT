using CreditSuisse.Trades.Util;

namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    internal class LowRisk : ITradeCategory
    {
        public string Name { get => Constants.Category.LOWRISK; }

        private const double _limitValue = 1_000_000;

        public LowRisk()
        {
        }

        public bool IsMatch(ITrade trade)
        {
            return trade.ClientSector == Constants.ClientSector.PUBLIC && trade.Value < _limitValue;
        }
    }
}
