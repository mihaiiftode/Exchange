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
            var sut = new CommandLineParser<FxExchange>();

            // act
            sut.Parse(new[] {"DKK/USD", "20"});

            // assert
            sut.ParsedObject.ShouldNotBeNull();
            sut.ParsedObject.From.ShouldBe("DKK");
            sut.ParsedObject.To.ShouldBe("USD");
            sut.ParsedObject.Amount.ShouldBe(20);
        }

        [Fact]
        public void WithSuccess_Callback_IsExecuted()
        {
            // arrange
            var sut = new CommandLineParser<FxExchange>();

            // act
            // assert
            sut.Parse(new[] {"DKK/USD", "20"})
                .WithSuccess(exchange => { exchange.ShouldNotBeNull(); });
        }

        [Fact]
        public void WithError_Callback_IsExecuted()
        {
            // arrange
            var sut = new CommandLineParser<FxExchange>();

            // act
            // assert
            sut.Parse(new[] {"DKK/USD", "20"})
                .WithError(s => s.ShouldBe("Unable to parse input data!"));
        }
    }
}