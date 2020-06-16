using System;
using Exchange.Model;

namespace Exchange.Contracts
{
    public interface ICommandLineParser
    {
        string Error { get; }
        FxExchange ParsedObject { get; }
        ICommandLineParser Parse(string[] args);
        ICommandLineParser WithError(Action<string> action);
        ICommandLineParser WithSuccess(Action<FxExchange> action);
    }
}