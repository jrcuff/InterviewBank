using System.Text.RegularExpressions;

namespace InterviewBank.Domain
{
    public class Account
    {
        public string AccountNumber { get; }
        public string BIN { get; }
        public string ClientId { get; }
        public int Balance { get; private set; }

        public Account(string accountNumber, string bin, string clientId, int balance)
        {
            AccountNumber = IsAccountNumberValid(accountNumber) ? accountNumber.ToLowerInvariant() : throw new ArgumentException("Account number should be 7 letters/numbers", nameof(accountNumber));
            BIN = IsBinValid(bin) ? bin : throw new ArgumentException("Account number should be 3 numbers", nameof(bin));
            ClientId = IsClientIdValid(clientId) ? clientId : throw new ArgumentException("Client id should be 7 numbers", nameof(clientId));
            Balance = IsBalanceValid(balance) ? balance : throw new ArgumentException("Balance should be greater than or equal to 0", nameof(balance));
        }

        public void Credit(int amount)
        {
            // Validate input
            // Change state
        }

        public void Debit(int amount)
        {
            // Validate input
            // Change state
        }

        private static bool IsAccountNumberValid(string accountNumber)
        {
            var regex = new Regex("^[a-zA-Z0-9]{7}$");
            return regex.IsMatch(accountNumber);
        }

        private static bool IsBinValid(string bin)
        {
            var regex = new Regex("^[0-9]{3}$");
            return regex.IsMatch(bin);
        }

        private static bool IsClientIdValid(string clientId)
        {
            var regex = new Regex("^[0-9]{7}$");
            return regex.IsMatch(clientId);
        }

        private static bool IsBalanceValid(int balance)
        {
            return balance >= 0;
        }
    }
}