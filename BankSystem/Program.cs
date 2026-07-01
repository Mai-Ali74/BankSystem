using BankSystem.Services;
using BankSystem.Interfaces;
using BankSystem.Models.Enums;
using BankSystem.UI;

public class Program
{
    public static void Main(string[] args)
    {
        IBankService bankService = new BankService();

        bankService.AddCustomer(101, "Mai Ali", "01012345678", "12345");
        bankService.CreateAccount(101, 1001, AccountType.Saving);

        BankMenu mainMenu = new BankMenu(bankService);
        mainMenu.Display();
    }
}