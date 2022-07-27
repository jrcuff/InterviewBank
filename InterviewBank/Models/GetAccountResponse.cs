namespace InterviewBank.Models
{
    public class GetAccountResponse
    {
        public string AccountNumber { get; set; }
        public string BIN { get; set; }
        public string ClientId { get; set; }
        public int Balance { get; set; }
    }
}
