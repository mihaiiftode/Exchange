using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Exchange.Test.Common
{
    public class AutoMockAttribute : AutoDataAttribute
    {
        public AutoMockAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}