using InterviewBank.Domain;

namespace InterviewBank.UnitTests.AdvanceTests
{
    public class FlagTransactionsTests : TestBase
    {
        public FlagTransactionsTests()
        {
            
        }

        [Fact]
        public void GivenTransactionUnder10k_WhenNewTransaction_ThenNotFlagged()
        {
            // Arrange
            var transaction = new Transaction("123", "45jmsh2", 9999);

            // Act, Assert
            Assert.False(transaction.IsFlagged);
        }

        [Fact]
        public void GivenTransactionOverOrEqual10k_WhenNewTransaction_ThenFlagged()
        {
            // Arrange
            var transaction = new Transaction("123", "45jmsh2", 10000);

            // Act, Assert
            Assert.True(transaction.IsFlagged);
        }
    }
}
