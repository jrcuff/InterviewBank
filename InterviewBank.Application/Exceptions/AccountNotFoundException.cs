namespace InterviewBank.Application.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string s) : base(s)
        {
        }
    }
}
