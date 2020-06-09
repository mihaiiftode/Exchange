using System;

namespace Exchange.Exceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string message) : base(message)
        {
        }
    }
}