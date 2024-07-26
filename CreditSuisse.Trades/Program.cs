using CreditSuisse.Trades.Infrastructure.Trade;
using CreditSuisse.Trades.Trade;
using CreditSuisse.Trades.Util;

namespace CreditSuisse.Trades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TradeService tradeService = new TradeService();
            List<ITrade> tradeList = new List<ITrade>();
            tradeList.Add(new Commodity(1_000_000, Constants.ClientSector.PRIVATE));
            tradeList.Add(new Commodity(1_000_000, Constants.ClientSector.PUBLIC));
            tradeList.Add(new Commodity(1_000, Constants.ClientSector.PRIVATE));
            tradeList.Add(new Commodity(1_000, Constants.ClientSector.PUBLIC));

            var result = tradeService.GetCategory(tradeList);

            foreach (var category in result)
            {
                Console.WriteLine($"Item: {category}");
            }
        }
    }
}