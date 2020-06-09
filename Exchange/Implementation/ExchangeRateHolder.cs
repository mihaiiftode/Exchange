using System.Collections.Generic;

namespace Exchange
{
    public class ExchangeRateHolder
    {
        public readonly Dictionary<string, double> ExchangeRates = new Dictionary<string, double>
        {
            {"EUR", 743.94},
            {"USD", 663.11},
            {"GBP", 852.85},
            {"SEK", 76.10},
            {"NOK", 78.40},
            {"CHF", 683.58},
            {"JPY", 7.9748},
            {"DKK", 100.00},
        };
    }
}