using InterviewBank.Application;
using InterviewBank.Domain.Exceptions;

namespace InterviewBank.UnitTests.AdvanceTests
{
    public class LastTwoWeeksTransactionTests : TestBase
    {
        public LastTwoWeeksTransactionTests()
        {
            var fourteenDaysAgo = DateTime.UtcNow.AddDays(-14) + TimeSpan.FromMinutes(1);
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "45jmsh2", IsFlagged = true, Amount = 10, Timestamp = fourteenDaysAgo });
            Context.SaveChanges();
        }

        [Fact]
        public async Task GivenTransactionGreaterThan2Weeks_WhenDebit_ThenNoError()
        {
            // Arrange
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "smn4592", IsFlagged = true, Amount = 10, Timestamp = DateTime.UtcNow.AddDays(-20) });
            await Context.SaveChangesAsync();
            var debitAccountUseCase = new DebitAccountUseCase(Context);

            // Act, Assert
            await debitAccountUseCase.DebitAccount("smn4592", 0);
        }

        [Fact]
        public async Task GivenTransactionNotFlagged_WhenDebit_ThenNoError()
        {
            // Arrange
            Context.Transactions.Add(new Database.Models.Transaction()
                { Id = "123", AccountNumber = "smn4592", IsFlagged = false, Amount = 10 });
            await Context.SaveChangesAsync();
            var debitAccountUseCase = new DebitAccountUseCase(Context);

            // Act, Assert
            await debitAccountUseCase.DebitAccount("smn4592", 0);
        }

        [Fact]
        public async Task GivenTransactionWithin2Weeks_WhenDebit_ThenError()
        {
            // Arrange
            var debitAccountUseCase = new DebitAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => debitAccountUseCase.DebitAccount("45jmsh2", 0));
        }

        [Fact]
        public async Task GivenTransactionWithin2Weeks_WhenCredit_ThenError()
        {
            // Arrange
            var creditAccountUseCase = new CreditAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => creditAccountUseCase.CreditAccount("45jmsh2", 0));
        }

        [Fact]
        public async Task GivenTransactionFromWithin2Weeks_WhenTransfer_ThenError()
        {
            // Arrange
            var transferAccountUseCase = new TransferAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => transferAccountUseCase.TransferAccount("45jmsh2", "smn4592", 0));
        }

        [Fact]
        public async Task GivenTransactionToWithin2Weeks_WhenTransfer_ThenError()
        {
            // Arrange
            var transferAccountUseCase = new TransferAccountUseCase(Context);

            // Act, Assert
            await Assert.ThrowsAsync<OperationDeniedException>(() => transferAccountUseCase.TransferAccount("smn4592", "45jmsh2", 0));
        }
    }
}
