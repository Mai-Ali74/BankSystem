using BankSystem.Models.Abstractions;
using BankSystem.Models.Enums;
namespace BankSystem.Models.Entities
{
    public class CurrentAccount : Account
    {
        public decimal OverDraftLimit { get; set; } = 500m;
        public CurrentAccount(int accountNumber) : base(accountNumber)
        {
        }

        public override bool Withdraw(decimal amount)
        {
            if (Status != AccountStatus.Active || amount <= 0)
            {
                return false;
            }
            if (Balance + OverDraftLimit >= amount)
            {
                Balance -= amount;
                AddTransaction("Withdraw", amount);
                return true;
            }
                return false;
            
        }
    }
}
