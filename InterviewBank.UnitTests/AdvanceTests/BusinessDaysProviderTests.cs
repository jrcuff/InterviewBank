using InterviewBank.Application;

namespace InterviewBank.UnitTests.AdvanceTests
{
    public class BusinessDaysProviderTests : TestBase
    {
        public BusinessDaysProviderTests()
        {
            
        }

        [Fact]
        public void Given2WeeksInclusive_WhenGetBusinessDays_ThenReturn10()
        {
            // Arrange
            var start = new DateTime(2022, 7, 25); // Monday
            var end = start.AddDays(14);
            
            // Act
            var businessDays = BusinessDaysProvider.GetBusinessDays(start, end);

            // Assert
            Assert.Equal(10, businessDays);
        }
    }
}
