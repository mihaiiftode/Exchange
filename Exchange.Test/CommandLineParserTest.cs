using Exchange.Implementation;
using Shouldly;
using Xunit;

namespace Exchange.Test
{
    public class CommandLineParserTest
    {
        [Fact]
        public void Parse_ParsesFxExchange_Command()
        {
            // arrange
            var sut = new CommandLineParser();

            // act
            sut.Parse(new[] {"DKK/USD", "20"});

            // assert
            sut.ParsedObject.ShouldNotBeNull();
            sut.ParsedObject.CurrencyPair.From.ShouldBe("DKK");
            sut.ParsedObject.CurrencyPair.To.ShouldBe("USD");
            sut.ParsedObject.Amount.ShouldBe(20);
        }

        [Fact]
        public void WithSuccess_Callback_IsExecuted()
        {
            // arrange
            var sut = new CommandLineParser();

            // act
            // assert
            sut.Parse(new[] {"DKK/USD", "20"})
                .WithSuccess(exchange =>
                {
                    exchange.CurrencyPair.From.ShouldBe("DKK");
                    exchange.CurrencyPair.To.ShouldBe("USD");
                    exchange.Amount.ShouldBe(20);
                });
        }

        [Theory]
        [InlineData(new string[0], Constants.NoArgs)]
        [InlineData(new[] {"test"}, Constants.InvalidNumberOfArgs)]
        [InlineData(new[] {"DKK/USD", "test"}, Constants.UnableToParseAmount)]
        [InlineData(new[] {"DKKUSD", "20"}, Constants.CurrencyPairIncorrectFormat)]
        public void WithError_Callback_IsExecuted(string[] data, string expectedMessage)
        {
            // arrange
            var sut = new CommandLineParser();

            // act
            // assert
            sut.Parse(data)
                .WithError(s => s.ShouldBe(expectedMessage));
        }
    }
}