namespace BankSystem.Models.Entities
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }

        public Transaction(string type, decimal amount, decimal balanceAfter)
        {
            Date = DateTime.Now;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
        }
    }
}
