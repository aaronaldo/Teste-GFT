namespace CreditSuisse.Trades.Infrastructure.Trade.Category
{
    public class CategoryFactory
    {
        private List<ITradeCategory> _categories = new();

        public CategoryFactory()
        {
            _categories.Add(new LowRisk());
            _categories.Add(new MediumRisk());
            _categories.Add(new HighRisk());
            _categories.Add(new NotThatHighRisk());
        }

        public ITradeCategory GetCategory(ITrade trade)
        {
            foreach (var category in _categories)
            {
                if (category.IsMatch(trade))
                    return category;
            }

            // TODO: review with business (aka the responsible for this test) if trades with unknown categories must break the application, or just be ignored
            
            // This line is considering that it must break the app
            //throw new ArgumentException($"Category not found for given trade: Sector: {trade.ClientSector}, Value: {trade.Value}");

            // This line is considering that it must be ignored
            return null;
        }

        // If needed, it can be added in run time
        public void AddCategory(ITradeCategory tradeCategory)
        {
            _categories.Add(tradeCategory);
        }
    }
}
