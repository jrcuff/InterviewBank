using InterviewBank.Database;
using Microsoft.EntityFrameworkCore;

namespace InterviewBank.Application
{
    public class RetrieveAccountUseCase
    {
        private readonly BankDbContext _context;

        public RetrieveAccountUseCase(BankDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Account>> RetrieveAccounts(CancellationToken cancellationToken)
        {
            var accounts = _context.Accounts
                .AsNoTracking()
                .Select(x => new Domain.Account(x.AccountNumber, x.BIN, x.ClientId, x.Balance));
            
            return await accounts.ToListAsync(cancellationToken);
        }
    }
}
