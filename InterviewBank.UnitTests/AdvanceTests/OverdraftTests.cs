using InterviewBank.Domain;

namespace InterviewBank.UnitTests.AdvanceTests
{
    public class OverdraftTests : TestBase
    {
        public OverdraftTests()
        {
            
        }

        [Fact]
        public void GivenNegativeBalanceWithinLimit_WhenDebit_ThenDebit()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", -90);
            // Act
            account.Debit(10);
            // Assert
            Assert.Equal(-100, account.Balance);
        }

        [Fact]
        public void GivenNegativeBalanceOutsideLimit_WhenDebit_ThenError()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", -90);
            // Act, Assert
            Assert.Throws<ArgumentException>(() => account.Debit(11));
        }
    }
}
