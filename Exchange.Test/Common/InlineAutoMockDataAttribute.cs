using AutoFixture.Xunit2;
using Exchange.Test.Common;
using Xunit;

namespace Engage.TestHelpers
{
    public class InlineAutoMockDataAttribute : CompositeDataAttribute
    {
        public InlineAutoMockDataAttribute(params object[] values)
            : base(new InlineDataAttribute(values), new AutoMockAttribute())
        {
        }
    }
}