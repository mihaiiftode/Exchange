using System;

namespace Exchange
{
    public class CommandLineParser<T> where T : new()
    {
        public string Error { get; private set; }
        public T ParsedObject { get; private set; }

        public CommandLineParser<T> Parse(string[] args)
        {
            return this;
        }

        public CommandLineParser<T> WithError(Action<string> action)
        {
            action(Error);
            return this;
        }

        public CommandLineParser<T> WithSuccess(Action<T> action)
        {
            action(ParsedObject);
            return this;
        }
    }
}