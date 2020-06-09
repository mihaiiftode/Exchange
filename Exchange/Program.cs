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
            var exchanger = new CurrencyExchanger(new ExchangeRateHolder(100));

            try
            {
                Console.WriteLine(exchanger.Exchange(fxExchange));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}