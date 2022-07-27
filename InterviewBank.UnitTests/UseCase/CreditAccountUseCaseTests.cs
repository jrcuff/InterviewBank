using InterviewBank.Application;
using InterviewBank.Application.Exceptions;
using InterviewBank.Database.Models;

namespace InterviewBank.UnitTests.UseCase
{
    public class CreditAccountUseCaseTests : TestBase
    {
        private readonly CreditAccountUseCase _creditAccountUseCase;

        public CreditAccountUseCaseTests()
        {
            _creditAccountUseCase = new CreditAccountUseCase(Context);
        }

        [Fact]
        public async Task GivenCorrectAccount_WhenCredit_ThenCreditAccount()
        {
            // Arrange, Act
            await _creditAccountUseCase.CreditAccount("45jmsh2", 10);

            // Assert
            Assert.Equal(10, Context.Find<Account>("45jmsh2")!.Balance);
        }

        [Fact]
        public async Task GivenInvalidAccount_WhenCredit_ThenError()
        {
            // Arrange, Act, Assert
            await Assert.ThrowsAsync<AccountNotFoundException>(() => _creditAccountUseCase.CreditAccount("nonExistingAccount", 10));
        }
    }
}