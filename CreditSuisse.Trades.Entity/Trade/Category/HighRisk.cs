using CreditSuisse.Trades.Util;

namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    internal class HighRisk : ITradeCategory
    {
        public string Name { get => Constants.Category.HIGHRISK; }

        private const double _minimumValue = 1_000_000;

        public HighRisk()
        {
        }

        public bool IsMatch(ITrade trade)
        {
            return trade.ClientSector == Constants.ClientSector.PRIVATE && trade.Value >= _minimumValue;
        }
    }
}
