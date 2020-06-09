using System.Collections.Generic;

namespace Exchange.Contracts
{
    public interface IExchangeRateHolder
    {
        Dictionary<string, double> ExchangeRates { get; }
        double BaseAmount { get; }
    }
}