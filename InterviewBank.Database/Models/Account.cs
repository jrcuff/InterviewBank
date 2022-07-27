using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace InterviewBank.Database.Models
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }

        [ForeignKey(nameof(Bank))]
        public string BIN { get; set; }
        public Bank Bank { get; set; }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public Client Client { get; set; }

        public int Balance { get; set; }
    }
}
