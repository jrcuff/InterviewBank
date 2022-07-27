using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace InterviewBank.Database.Models
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Account))]
        public string AccountNumber { get; set; }
        public Account Account { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool IsFlagged { get; set; }
        public int Amount { get; set; }
    }
}
