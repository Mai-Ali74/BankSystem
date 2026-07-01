using BankSystem.Interfaces;
using BankSystem.Models.Abstractions;
using BankSystem.Models.Entities;
using BankSystem.Models.Enums;

namespace BankSystem.Services
{
    public class BankService : IBankService
    {
        private readonly List<Customer> _customers = new List<Customer>();
        private readonly List<Employee> _employees = new List<Employee>();

        public BankService()
        {
            _employees.Add(new Employee(1, "System Admin", "01234567891", "Admin", "Admin123"));

        }

        public bool AdminLogin(int id, string password)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == id);
            return emp!= null && emp.ValidatePassword(password);
        }

        public Customer? FindCustomer(int customerId)
        {
            return _customers.FirstOrDefault(c => c.Id == customerId);
        }


        public Account? FindAccount(int accountNumber)
        {
            return _customers.SelectMany(c => c.Accounts).FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public Customer? GetAccountOwner(int accountNumber)
        {
            return _customers.FirstOrDefault(c => c.Accounts.Any(a => a.AccountNumber == accountNumber));
        }

        public bool AuthenticateUser(int accountNumber, string pin)
        {
            var owner = GetAccountOwner(accountNumber);
            return owner != null && owner.ValidatePin(pin);

        }

        public bool AddCustomer(int id, string name , string phone , string pin)
        {

            if (FindCustomer(id) != null)
            {
                return false;
            }

            _customers.Add(new Customer(id, name, phone,pin));
            return true;
        }
       
        public bool CreateAccount(int customerId, int accountNumber, AccountType type)
        {

            var customer = FindCustomer(customerId);

            if (customer == null || FindAccount(accountNumber)!= null)
            {
                return false;
            }
            Account newAccount = type switch
            {
                AccountType.Saving => new SavingAccount(accountNumber),
                AccountType.Current=> new CurrentAccount(accountNumber),
                _ => null
            };

            if(newAccount == null) 
                return false;

            customer.Accounts.Add(newAccount);
            return true;
           
        }
       

        public bool Deposit(int accountNumber , decimal amount)
        {

            var account = FindAccount(accountNumber);
            if(account==null || account.Status != AccountStatus.Active)
                return false;

            return account.Deposit(amount);

        }

        public bool Withdraw(int accountNumber , string pin ,decimal amount)
        {
            if(!AuthenticateUser(accountNumber,pin))
                return false;
            var account = FindAccount(accountNumber);
            if(account == null || account.Status != AccountStatus.Active)
                return false;
             return account.Withdraw(amount);
        }

        public bool Transfer(int fromAccountNumber , string pin , int toAccountNumber, decimal amount)
         {

            if (!AuthenticateUser(fromAccountNumber, pin) || fromAccountNumber == toAccountNumber)
                return false;

            var sender = FindAccount(fromAccountNumber);
            var receiver = FindAccount(toAccountNumber);

            if( sender == null || receiver == null)
                return false;
            
            if(receiver.Status != AccountStatus.Active) 
                return false;


            if (sender.Withdraw(amount))
            {

               if(!receiver.Deposit(amount))
                {
                    sender.Deposit(amount);
                    return false;
                }
                return true;
            }

            return false;
        }

        public bool ChangeAccountStatus(int accountNumber , AccountStatus newStatus)
        {
            var account = FindAccount(accountNumber);

            if(account==null) 
                return false;

            account.Status = newStatus;
            return true;
        }


        public bool ApplyInterestToSavings(int accountNumber)
        {
            var account = FindAccount(accountNumber);

            if (account is SavingAccount savingAcc)
            {
                return savingAcc.ApplyInterest();
            }

            return false;
        }
    }
}




