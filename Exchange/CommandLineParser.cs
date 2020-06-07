using System;

namespace Exchange
{
    public class CommandLineParser
    {
        public string Error { get; private set; }
        public FxExchange ParsedObject { get; private set; }

        public CommandLineParser Parse(string[] args)
        {
            if (args.Length == 0)
            {
                Error = Constants.NoArgs;
            }
            else if (args.Length != 2)
            {
                Error = Constants.InvalidNumberOfArgs;
            }
            else
            {
                var currencyPair = args[0].Split("/");
                if (currencyPair.Length != 2)
                {
                    Error = Constants.CurrencyPairIncorrectFormat;
                    return this;
                }

                if (!int.TryParse(args[1], out var result))
                {
                    Error = Constants.UnableToParseAmount;
                    return this;
                }

                ParsedObject = new FxExchange
                {
                    From = currencyPair[0],
                    To = currencyPair[1],
                    Amount = result
                };
            }

            return this;
        }

        public CommandLineParser WithError(Action<string> action)
        {
            if (!string.IsNullOrWhiteSpace(Error))
            {
                action(Error);
            }

            return this;
        }

        public CommandLineParser WithSuccess(Action<FxExchange> action)
        {
            if (!(ParsedObject is null))
            {
                action(ParsedObject);
            }

            return this;
        }
    }
}