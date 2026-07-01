using BankSystem.Models.Entities;
using BankSystem.Models.Enums;


namespace BankSystem.Models.Abstractions
{
    public abstract class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public AccountStatus Status { get;  set; } = AccountStatus.Active;

        private readonly List<Transaction> _transactions = new List<Transaction>();

        public IReadOnlyCollection<Transaction>Transactions => _transactions.AsReadOnly();
        protected Account(int accountNumber) 
        {
           AccountNumber = accountNumber;
            Balance = 0;
        }

        protected void AddTransaction(string type , decimal amount)
        {
            _transactions.Add(new Transaction(type, amount,Balance));
        }
        public virtual bool Deposit(decimal amount)
        {
            if (Status != AccountStatus.Active || amount <= 0)
                return false;
            
                Balance += amount;
            AddTransaction("Deposit", amount);
                    return true;
        }
        public abstract bool Withdraw(decimal amount);
    }
}
