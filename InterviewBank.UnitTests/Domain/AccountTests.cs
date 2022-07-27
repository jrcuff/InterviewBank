using InterviewBank.Domain;
using InterviewBank.Domain.Exceptions;

namespace InterviewBank.UnitTests.Domain
{
    public class AccountTests
    {
        public AccountTests()
        {
            
        }

        [Fact]
        public void GivenValidAccount_WhenCreatingAccount_ReturnAccount()
        {
            // Arrange, Act, Assert
            var _ = new Account("abcd123", "000", "1234567", 0);
        }

        [Fact]
        public void GivenInvalidAccountNumber_WhenCreatingAccount_Throw()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => _ = new Account("a", "000", "1234567", 0));
        }

        [Fact]
        public void GivenInvalidBin_WhenCreatingAccount_Throw()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => _ = new Account("abcd123", "0", "1234567", 0));
        }

        [Fact]
        public void GivenInvalidClientId_WhenCreatingAccount_Throw()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => _ = new Account("abcd123", "000", "1", 0));
        }

        [Fact]
        public void GivenInvalidBalance_WhenCreatingAccount_Throw()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => _ = new Account("abcd123", "000", "1234567", -1));
        }

        [Fact]
        public void GivenValidAmount_WhenCrediting_CreditAccount()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", 0);
            // Act
            account.Credit(10);
            // Assert
            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void GivenInvalidAmount_WhenCrediting_Throw()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", 0);
            // Act, Assert
            Assert.Throws<ArgumentException>(() => account.Credit(-1));
        }

        [Fact]
        public void GivenValidAmount_WhenDebiting_DebitAccount()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", 10);
            // Act
            account.Debit(10);
            // Assert
            Assert.Equal(0, account.Balance);
        }

        [Fact]
        public void GivenInvalidAmount_WhenDebiting_Throw()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", 0);
            // Act, Assert
            Assert.Throws<ArgumentException>(() => account.Debit(-1));
        }

        [Fact]
        public void GivenAmountGreaterThanBalance_WhenDebiting_Throw()
        {
            // Arrange
            var account = new Account("abcd123", "000", "1234567", 0);
            // Act, Assert
            Assert.Throws<NonSufficientFundsException>(() => account.Debit(1));
        }
    }
}
