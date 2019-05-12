namespace Modulus.Shared.Models
{
    public class AccountInfo
    {
        public string SortCode { get; }
        public string AccountNumber { get; }

        public AccountInfo(string sortCode, string accountNumber)
        {
            SortCode = sortCode;
            AccountNumber = accountNumber;
        }
    }
}