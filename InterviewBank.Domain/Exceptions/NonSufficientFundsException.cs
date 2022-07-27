namespace InterviewBank.Domain.Exceptions
{
    public class NonSufficientFundsException : System.Exception
    {
        public NonSufficientFundsException(string s) : base(s)
        {
        }
    }
}
