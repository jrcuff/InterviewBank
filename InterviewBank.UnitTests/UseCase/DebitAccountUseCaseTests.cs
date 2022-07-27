using InterviewBank.Application;
using InterviewBank.Application.Exceptions;
using InterviewBank.Database.Models;

namespace InterviewBank.UnitTests.UseCase
{
    public class DebitAccountUseCaseTests : TestBase
    {
        private readonly DebitAccountUseCase _debitAccountUseCase;

        public DebitAccountUseCaseTests()
        {
            _debitAccountUseCase = new DebitAccountUseCase(Context);
            Context.Accounts.Find("45jmsh2")!.Balance = 10;
            Context.SaveChanges();
        }

        [Fact]
        public async Task GivenCorrectAccount_WhenDebit_ThenDebitAccount()
        {
            // Arrange, Act
            await _debitAccountUseCase.DebitAccount("45jmsh2", 10);

            // Assert
            Assert.Equal(0, Context.Find<Account>("45jmsh2")!.Balance);
        }

        [Fact]
        public async Task GivenInvalidAccount_WhenDebit_ThenError()
        {
            // Arrange, Act, Assert
            await Assert.ThrowsAsync<AccountNotFoundException>(() => _debitAccountUseCase.DebitAccount("nonExistingAccount", 10));
        }
    }
}