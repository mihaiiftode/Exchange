using System;
using Exchange.Contracts;
using Exchange.Exceptions;
using Exchange.Model;

namespace Exchange.Implementation
{
    public class CurrencyExchanger : ICurrencyExchanger
    {
        private readonly IExchangeRateHolder _exchangeRateHolder;

        public CurrencyExchanger(IExchangeRateHolder exchangeRateHolder)
        {
            _exchangeRateHolder = exchangeRateHolder ?? throw new ArgumentNullException(nameof(exchangeRateHolder));
        }

        public double Exchange(FxExchange exchange)
        {
            var currencyPair = exchange.CurrencyPair;
            if (currencyPair.From == currencyPair.To) return exchange.Amount;

            var hasFrom = _exchangeRateHolder.ExchangeRates.TryGetValue(currencyPair.From.ToUpper(), out var from);
            var hasTo = _exchangeRateHolder.ExchangeRates.TryGetValue(currencyPair.To.ToUpper(), out var to);

            if (hasFrom && hasTo)
            {
                return Math.Round(from * exchange.Amount / to, 4);
            }

            throw new InvalidCurrencyException(string.Format(Constants.CurrencyNotFound, hasFrom ? currencyPair.To : currencyPair.From));
        }
    }
}