namespace InterviewBank.Domain
{
    public class Transaction
    {
        public string Id { get; }
        public string AccountNumber { get; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool IsFlagged { get; }
        public int Amount { get; }

        public Transaction(string id, string accountNumber, int amount, DateTime timestamp)
        {
            Id = id;
            AccountNumber = accountNumber;
            Amount = amount;
            IsFlagged = false;
            Timestamp = timestamp;
        }

        public Transaction(string id, string accountNumber, int amount)
        {
            Id = id;
            AccountNumber = accountNumber;
            Amount = amount;
            IsFlagged = false;
        }
    }
}
