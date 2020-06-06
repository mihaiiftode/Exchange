using System;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var command = new CommandLineParser<FxExchange>();

            command.Parse(args)
                .WithError(Console.WriteLine)
                .WithSuccess(ob => { });
        }
    }
}