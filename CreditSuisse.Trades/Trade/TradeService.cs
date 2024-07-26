using CreditSuisse.Trades.Infrastructure.Trade;
using CreditSuisse.Trades.Infrastructure.Trade.Category;

namespace CreditSuisse.Trades.Trade
{
    internal class TradeService
    {
        public List<string> GetCategory(List<ITrade> trades)
        {
            if (trades is null || trades.Count == 0)
                throw new ArgumentException(nameof(trades));

            List<string> categories = new();
            CategoryFactory categoryFactory = new CategoryFactory();
            Categorizer categorizer = new Categorizer(categoryFactory);

            foreach (ITrade trade in trades)
                categories.Add(categorizer.GetCategoryName(trade));
            
            return categories;
        }
    }
}
