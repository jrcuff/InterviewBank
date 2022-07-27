using InterviewBank.Application;
using InterviewBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterviewBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly RetrieveAccountUseCase _retrieveAccountUseCase;
        private readonly CreditAccountUseCase _creditAccountUseCase;
        private readonly DebitAccountUseCase _debitAccountUseCase;
        private readonly TransferAccountUseCase _transferAccountUseCase;

        public AccountController(RetrieveAccountUseCase retrieveAccountUseCase,
            CreditAccountUseCase creditAccountUseCase,
            DebitAccountUseCase debitAccountUseCase,
            TransferAccountUseCase transferAccountUseCase)
        {
            _retrieveAccountUseCase = retrieveAccountUseCase;
            _creditAccountUseCase = creditAccountUseCase;
            _debitAccountUseCase = debitAccountUseCase;
            _transferAccountUseCase = transferAccountUseCase;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAccountResponse>> GetAsync(CancellationToken cancellationToken)
        {
            return (await _retrieveAccountUseCase.RetrieveAccounts(cancellationToken))
                .Select(x => new GetAccountResponse()
                {
                    AccountNumber = x.AccountNumber,
                    BIN = x.BIN,
                    Balance = x.Balance,
                    ClientId = x.ClientId
                });
        }

        [HttpPost]
        [Route("{accountNumber}/Credit")]
        public async Task Credit(string accountNumber, int amount)
        {
            await _creditAccountUseCase.CreditAccount(accountNumber, amount);
        }

        [HttpPost]
        [Route("{accountNumber}/Debit")]
        public async Task Debit(string accountNumber, int amount)
        {
            await _debitAccountUseCase.DebitAccount(accountNumber, amount);
        }

        [HttpPost]
        [Route("{fromAccountNumber}/Transfer/{toAccountNumber}")]
        public async Task Transfer(string fromAccountNumber, string toAccountNumber, int amount)
        {
            await _transferAccountUseCase.TransferAccount(fromAccountNumber, toAccountNumber, amount);
        }
    }
}