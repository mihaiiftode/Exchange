using AutoFixture.Xunit2;
using Xunit;

namespace Exchange.Test.Common
{
    public class InlineAutoMockDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMockDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoMockAttribute())
        {
        }
    }
}