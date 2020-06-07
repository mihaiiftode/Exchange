using System;
using Exchange.Implementation;
using Exchange.Model;

namespace Exchange.Contracts
{
    public interface ICommandLineParser
    {
        string Error { get; }
        FxExchange ParsedObject { get; }
        CommandLineParser Parse(string[] args);
        CommandLineParser WithError(Action<string> action);
        CommandLineParser WithSuccess(Action<FxExchange> action);
    }
}