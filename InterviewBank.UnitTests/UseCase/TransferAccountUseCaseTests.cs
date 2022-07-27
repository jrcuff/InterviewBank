using InterviewBank.Application;
using InterviewBank.Application.Exceptions;
using InterviewBank.Database.Models;

namespace InterviewBank.UnitTests.UseCase
{
    public class TransferAccountUseCaseTests : TestBase
    {
        private readonly TransferAccountUseCase _transferAccountUseCase;

        public TransferAccountUseCaseTests()
        {
            _transferAccountUseCase = new TransferAccountUseCase(Context);
            Context.Accounts.Find("45jmsh2")!.Balance = 10;
            Context.SaveChanges();
        }

        [Fact]
        public async Task GivenCorrectAccount_WhenTransfer_ThenTransferAccount()
        {
            // Arrange, Act
            await _transferAccountUseCase.TransferAccount("45jmsh2", "smn4592", 10);

            // Assert
            Assert.Equal(0, Context.Find<Account>("45jmsh2")!.Balance);
            Assert.Equal(10, Context.Find<Account>("smn4592")!.Balance);
        }

        [Fact]
        public async Task GivenInvalidFromAccount_WhenTransfer_ThenError()
        {
            // Arrange, Act, Assert
            await Assert.ThrowsAsync<AccountNotFoundException>(() => _transferAccountUseCase.TransferAccount("nonExistingAccount", "45jmsh2", 10));
        }

        [Fact]
        public async Task GivenInvalidToAccount_WhenTransfer_ThenError()
        {
            // Arrange, Act, Assert
            await Assert.ThrowsAsync<AccountNotFoundException>(() => _transferAccountUseCase.TransferAccount("45jmsh2", "nonExistingAccount", 10));
        }
    }
}
