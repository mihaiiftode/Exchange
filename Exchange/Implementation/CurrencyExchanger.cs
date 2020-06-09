using System.Collections.Generic;
using Exchange.Model;

namespace Exchange
{
    public class CurrencyExchanger : ICurrencyExchanger
    {
        

        public double Exchange(FxExchange exchange)
        {
            if (exchange.From == exchange.To) return exchange.Amount;

            var hasFrom = ExchangeRates.TryGetValue(exchange.From, out var from);
            var hasTo = ExchangeRates.TryGetValue(exchange.From, out var to);

            if (hasFrom && hasTo)
            {
                return from / 100 * exchange.Amount / (to / 100);
            }
            else
            {
                throw new InvalidCurrencyException(string.Format(Constants.CurrencyNotFound, hasFrom ? to : from));
            }
        }
    }
}