using InterviewBank.Database;

namespace InterviewBank.Application
{
    public class DebitAccountUseCase
    {
        private readonly BankDbContext _dbContext;
        public DebitAccountUseCase(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DebitAccount(string accountNumber, int amount)
        {
            // Validate account exists
            // Debit
            // Save result to DB
        }
    }
}