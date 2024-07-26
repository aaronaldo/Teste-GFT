namespace CreditSuisse.Trades.Infrastructure.Trade
{
    // This is just an example on how I would create trade models in a real world app, but it's not relevant to the test
    public class Commodity : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }
        public Commodity()
        {   
        }

        public Commodity(double value, string clientSector)
        {
            Value = value;
            ClientSector = clientSector;
        }
        // (rest of the code)
    }
}
