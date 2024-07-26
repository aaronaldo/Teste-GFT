namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    public class Categorizer
    {
        private readonly CategoryFactory _categoryFactory;

        public Categorizer(CategoryFactory categoryFactory)
        {
            _categoryFactory = categoryFactory;
        }

        public string GetCategoryName(ITrade trade)
        {
            ITradeCategory tradeCategory = _categoryFactory.GetCategory(trade);
            return tradeCategory?.Name;
        }
    }
}
