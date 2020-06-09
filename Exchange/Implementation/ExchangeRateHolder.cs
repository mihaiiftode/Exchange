using System.Collections.Generic;
using Exchange.Contracts;

namespace Exchange.Implementation
{
    public class ExchangeRateHolder : IExchangeRateHolder
    {
        public double BaseAmount { get; }

        public Dictionary<string, double> ExchangeRates { get; }

        public ExchangeRateHolder(double baseAmount)
        {
            BaseAmount = baseAmount;

            ExchangeRates = new Dictionary<string, double>
            {
                {"EUR", 743.94},
                {"USD", 663.11},
                {"GBP", 852.85},
                {"SEK", 76.10},
                {"NOK", 78.40},
                {"CHF", 683.58},
                {"JPY", 7.9748},
                // Cache the base amount for easy access
                {"DKK", BaseAmount},
            };
        }
    }
}