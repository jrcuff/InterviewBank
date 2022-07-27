using InterviewBank.Application;
using InterviewBank.Domain.Exceptions;

namespace InterviewBank.UnitTests.AdvanceTests
{
    public class MoneyBlockedTests : TestBase
    {
        public MoneyBlockedTests()
        {
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "45jmsh2", Amount = 10, Timestamp = DateTime.UtcNow });

            Context.SaveChanges();
        }

        [Fact]
        public async Task GivenTransactionWithin5Days_WhenCredit_ThenThrow()
        {
            // Arrange
            var debitUseCase = new DebitAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => debitUseCase.DebitAccount("45jmsh2", 1));
        }

        [Fact]
        public async Task GivenTransactionWithin5Days_WhenTransfer_ThenThrow()
        {
            // Arrange
            var debitUseCase = new TransferAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => debitUseCase.TransferAccount("45jmsh2", "smn4592", 1));
        }

        [Fact]
        public async Task GivenTransactionBefore5Days_WhenCredit_ThenSuccess()
        {
            // Arrange
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "smn4592", Amount = 10, Timestamp = DateTime.UtcNow.AddDays(-10) });
            await Context.SaveChangesAsync();
            var debitUseCase = new DebitAccountUseCase(Context);

            // Act, Assert
            await debitUseCase.DebitAccount("45jmsh2", 1);
        }

        [Fact]
        public async Task GivenTransactionBefore5Days_WhenTransfer_ThenSuccess()
        {
            // Arrange
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "smn4592", Amount = 10, Timestamp = DateTime.UtcNow.AddDays(-10) });
            await Context.SaveChangesAsync();
            var debitUseCase = new TransferAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => debitUseCase.TransferAccount("45jmsh2", "smn4592", 1));
        }
    }
}
