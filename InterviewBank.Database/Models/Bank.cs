using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace InterviewBank.Database.Models
{
    public class Bank
    {
        [Key]
        public string BIN { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
    }
}
