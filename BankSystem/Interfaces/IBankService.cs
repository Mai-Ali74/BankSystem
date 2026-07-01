using BankSystem.Models.Abstractions;
using BankSystem.Models.Entities;
using BankSystem.Models.Enums;

namespace BankSystem.Interfaces
{
    public interface IBankService
    {
        bool AdminLogin(int empId, string password);
        bool AddCustomer(int id, string name, string phone, string pin);
        bool CreateAccount(int customerId, int accountNumber, AccountType type);
        bool ChangeAccountStatus(int accountNumber, AccountStatus status);
        bool ApplyInterestToSavings(int accountNumber);
        bool Deposit(int accountNumber, decimal amount);
        bool Withdraw(int accountNumber, string pin, decimal amount);
        bool Transfer(int fromAccount, string pin, int toAccount, decimal amount);
        Account? FindAccount(int accountNumber);
        Customer? GetAccountOwner(int accountNumber);
    }
}
