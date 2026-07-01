using BankSystem.Models.Abstractions;
using BankSystem.Models.Enums;

namespace BankSystem.Models.Entities
{
    public class SavingAccount : Account
    {
        public decimal InterestRate { get; set; } = 0.05m; 
        public SavingAccount(int accountNumber) : base(accountNumber)
        {
        }

        public override bool Withdraw(decimal amount)
        {
            if (Status!= AccountStatus.Active || amount <= 0 || Balance < amount)
            {
                return false;
            }
                Balance -= amount;
                AddTransaction("Withdraw", amount);
                return true;
        }

        public bool ApplyInterest()
        {
            if (Status != AccountStatus.Active) 
                return false;

            decimal interest = InterestRate * Balance;
            Balance += interest;
            AddTransaction("Interest Added",interest);
            return true;

        }
    }
}
