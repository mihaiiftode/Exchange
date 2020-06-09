using System;
using Exchange.Contracts;
using Exchange.Model;

namespace Exchange.Implementation
{
    public class CommandLineParser : ICommandLineParser
    {
        public string Error { get; private set; }
        public FxExchange ParsedObject { get; private set; }

        public CommandLineParser Parse(string[] args)
        {
            if (ArgsAreNotValid(args))
            {
                return this;
            }

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
                CurrencyPair = new CurrencyPair
                {
                    From = currencyPair[0],
                    To = currencyPair[1]
                },
                Amount = result
            };

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

        private bool ArgsAreNotValid(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Error = Constants.NoArgs;
                    return true;
                case 2:
                    return false;
                default:
                    Error = Constants.InvalidNumberOfArgs;
                    return true;
            }
        }
    }
}