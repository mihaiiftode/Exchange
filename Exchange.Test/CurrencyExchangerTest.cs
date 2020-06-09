using Exchange.Contracts;
using Exchange.Exceptions;
using Exchange.Implementation;
using Exchange.Model;
using Exchange.Test.Common;
using Shouldly;
using Xunit;

namespace Exchange.Test
{
    public class CurrencyExchangerTest
    {
        [Theory, AutoMock]
        public void Exchange_ShouldReturnTheSameAmount_AsRequested(FxExchange exchange, IExchangeRateHolder rateHolder)
        {
            // arrange
            var sut = new CurrencyExchanger(rateHolder);
            exchange.CurrencyPair.From = exchange.CurrencyPair.To;
            // act
            var result = sut.Exchange(exchange);
            // assert

            result.ShouldBe(exchange.Amount);
        }

        [Theory]
        [InlineData("EUR", "DKK", 2, 14.8788)]
        [InlineData("DKK", "EUR", 10, 1.3442)]
        [InlineData("EUR", "USD", 2, 2.2438)]
        public void Exchange_ShouldExchangeTheAmount_AsRequested(string from, string to, int ammount, double expected)
        {
            // arrange
            var exchange = new FxExchange {Amount = ammount, CurrencyPair = new CurrencyPair {From = from, To = to}};

            var sut = new CurrencyExchanger(new ExchangeRateHolder(100));

            // act
            var result = sut.Exchange(exchange);

            // assert
            result.ShouldBe(expected);
        }

        [Theory, AutoMock]
        public void Exchange_ShouldThrow_WhenCurrencyIsNotFound(FxExchange exchange, IExchangeRateHolder rateHolder)
        {
            // arrange
            var sut = new CurrencyExchanger(rateHolder);

            // act
            // assert
            Should.Throw<InvalidCurrencyException>(() => sut.Exchange(exchange));
        }

        [Theory]
        [InlineData("EUR_", Constants.CurrencyNotFound)]
        [InlineData("USD2", Constants.CurrencyNotFound)]
        public void Exchange_ShouldThrow_WithMessage(string currency, string expected)
        {
            // arrange
            var exchange = new FxExchange
            {
                Amount = 1,
                CurrencyPair = new CurrencyPair {From = currency, To = "USD"}
            };
            var sut = new CurrencyExchanger(new ExchangeRateHolder(100));

            // act
            // assert
            var exception = Should.Throw<InvalidCurrencyException>(() => sut.Exchange(exchange));
            exception.Message.ShouldBe(string.Format(expected, currency));
        }

        [Theory]
        [InlineData("uSD", "eUr")]
        public void Exchange_IsCase_Insensitive(string from, string to)
        {
            // arrange
            var exchange = new FxExchange
            {
                Amount = 1,
                CurrencyPair = new CurrencyPair {From = from, To = to}
            };
            var sut = new CurrencyExchanger(new ExchangeRateHolder(100));

            // act
            // assert
            Should.NotThrow(() => sut.Exchange(exchange));
        }
    }
}