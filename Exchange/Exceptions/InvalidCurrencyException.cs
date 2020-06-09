using System;

namespace Exchange
{
    public class InvalidCurrency : Exception
    {
        public InvalidCurrency(string message) : base(message)
        {
        }
    }
}