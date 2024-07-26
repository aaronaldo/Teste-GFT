using CreditSuisse.Trades.Util;

namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    internal class MediumRisk : ITradeCategory
    {
        public string Name { get => Constants.Category.MEDIUMRISK; }

        private const double _minimumValue = 1_000_000;

        public MediumRisk()
        {
        }

        public bool IsMatch(ITrade trade)
        {
            return trade.ClientSector == Constants.ClientSector.PUBLIC && trade.Value >= _minimumValue;
        }
    }
}
