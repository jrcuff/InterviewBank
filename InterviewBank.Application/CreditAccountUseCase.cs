using InterviewBank.Database;

namespace InterviewBank.Application
{
    public class CreditAccountUseCase
    {
        private readonly BankDbContext _dbContext;
        public CreditAccountUseCase(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreditAccount(string accountNumber, int amount)
        {
            // Validate account exists
            // Credit
            // Save result to DB
        }
    }
}