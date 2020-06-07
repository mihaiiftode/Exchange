namespace Exchange
{
    public static class Constants
    {
        public const string NoArgs = "Usage: Exchange <currency pair> <amount>";
        public const string InvalidNumberOfArgs = "Invalid number of arguments \n" + NoArgs;
        public const string CurrencyPairIncorrectFormat = "Unable to parse currency pair \n" + NoArgs;
        public const string UnableToParseAmount = "The provided amount is not a number \n" + NoArgs;
    }
}