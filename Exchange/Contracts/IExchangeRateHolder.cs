using System.Collections.Generic;

namespace Exchange
{
    public interface IExchangeRateHolder
    {
        Dictionary<string, double> ExchangeRates { get; set; }
    }
}