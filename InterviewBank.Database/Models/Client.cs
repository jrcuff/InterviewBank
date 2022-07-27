using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace InterviewBank.Database.Models
{
    public class Client
    {
        [Key]
        public string Id { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public string Name { get; set; }
    }
}
