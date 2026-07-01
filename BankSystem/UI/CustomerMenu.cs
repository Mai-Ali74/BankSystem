using System;
using BankSystem.Interfaces;

namespace BankSystem.UI
{
    public class CustomerMenu
    {
        private readonly IBankService _bankService;

        public CustomerMenu(IBankService bankService)
        {
            _bankService = bankService;
        }

        public void Display()
        {
            bool customerSession = true;

            while (customerSession)
            {
                Console.WriteLine("\n---CUSTOMER MENU---");
                Console.WriteLine("1- Deposit\n2- Withdraw\n3- Transfer\n4- Check Balance\n5- Back To Main Menu");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        PerformDeposit();
                        break;
                    case 2:
                        PerformWithdraw();
                        break;
                    case 3:
                        PerformTransfer();
                        break;
                    case 4:
                        ShowAccountDetails();
                        break;
                    case 5:
                        customerSession = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }

        private void PerformDeposit()
        {
            Console.Write("Enter Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
                return;

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid Amount!");
                return;
            }

            if (_bankService.Deposit(accNum, amount))
                Console.WriteLine("Deposit Success!.");
            else
                Console.WriteLine("Deposit Failed!.");
        }

        private void PerformWithdraw()
        {
            Console.Write("Enter Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
                return;

            Console.Write("Enter PIN: ");
            string pin = Console.ReadLine();

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid Amount!");
                return;
            }

            if (_bankService.Withdraw(accNum, pin, amount))
                Console.WriteLine("Withdraw Success!.");
            else
                Console.WriteLine("Withdraw Failed!.");
        }

        private void PerformTransfer()
        {
            Console.Write("From Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int fromAcc))
                return;

            Console.Write("Enter PIN: ");
            string pin = Console.ReadLine();

            Console.Write("To Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int toAcc))
                return;

            Console.Write("Enter Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("Invalid Amount!");
                return;
            }

            if (_bankService.Transfer(fromAcc, pin, toAcc, amount))
                Console.WriteLine("Transfer Success!.");
            else
                Console.WriteLine("Transfer Failed!.");
        }

        private void ShowAccountDetails()
        {
            Console.Write("Enter Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
                return;

            var acc = _bankService.FindAccount(accNum);
            var owner = _bankService.GetAccountOwner(accNum);

            if (acc == null || owner == null)
            {
                Console.WriteLine("Account not found!");
                return;
            }

            Console.WriteLine($"\nAccount#{acc.AccountNumber} | Owner: {owner.Name} | Balance: {acc.Balance:C} | Status: {acc.Status}");

            Console.WriteLine("Transaction Log:");
            if (acc.Transactions.Count == 0)
            {
                Console.WriteLine("No Transactions found.");
                return;
            }

            foreach (var t in acc.Transactions)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"Date: {t.Date}\nType: {t.Type}\nAmount: {t.Amount:C}\nBalance: {t.BalanceAfter:C}");
            }
        }
    }
}