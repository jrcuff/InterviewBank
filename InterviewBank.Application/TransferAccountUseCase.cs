using InterviewBank.Database;

namespace InterviewBank.Application
{
    public class TransferAccountUseCase
    {
        private readonly BankDbContext _dbContext;
        public TransferAccountUseCase(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task TransferAccount(string sourceAccountNumber, string destAccountNumber, int amount)
        {
            // Validate accounts exists
            // Transfer
            // Save result to DB
        }
    }
}