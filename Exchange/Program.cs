using System;
using Exchange.Implementation;
using Exchange.Model;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = new CommandLineParser();

            command.Parse(args)
                .WithError(Console.WriteLine)
                .WithSuccess(ExecuteExchange);
        }

        private static void ExecuteExchange(FxExchange fxExchange)
        {
            
        }
    }
}