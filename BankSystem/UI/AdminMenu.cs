using System;
using BankSystem.Interfaces;
using BankSystem.Models.Enums;

namespace BankSystem.UI
{
    public class AdminMenu
    {
        private readonly IBankService _bankService;

        public AdminMenu(IBankService bankService)
        {
            _bankService = bankService;
        }

        public void Display()
        {
            Console.WriteLine("---Admin Login---");
            Console.Write("Enter Employee Id: ");
            if (!int.TryParse(Console.ReadLine(), out int empId))
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (!_bankService.AdminLogin(empId, password))
            {
                Console.WriteLine("Access Denied! Incorrect ID or Password");
                return;
            }

            Console.WriteLine("Login Successful!");
            bool adminSession = true;

            while (adminSession)
            {
                Console.WriteLine("\n---ADMIN MENU---");
                Console.WriteLine("1- Add Customer\n2- Create Account\n3- Change Account Status\n4- Apply Interest To Savings\n5- Back To Main Menu");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddNewCustomer();
                        break;
                    case 2:
                        AddNewAccount();
                        break;
                    case 3:
                        UpdateAccountStatus();
                        break;
                    case 4:
                        ApplyInterest();
                        break;
                    case 5:
                        adminSession = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }

        private void AddNewCustomer()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Set PIN Code: ");
            string pin = Console.ReadLine();

            if (_bankService.AddCustomer(id, name, phone, pin))
                Console.WriteLine("Customer Added Successfully!");
            else
                Console.WriteLine("Failed! Customer Id already exists.");
        }

        private void AddNewAccount()
        {
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int custId))
            {
                Console.WriteLine("Invalid Id!");
                return;
            }

            Console.Write("Enter New Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            Console.WriteLine("Select Type: 1. Saving | 2. Current");
            Console.Write("Type: ");

            if (!int.TryParse(Console.ReadLine(), out int typeInput) || (typeInput != 1 && typeInput != 2))
            {
                Console.WriteLine("Invalid type!");
                return;
            }

            AccountType type = (AccountType)typeInput;

            if (_bankService.CreateAccount(custId, accNum, type))
                Console.WriteLine("Account created successfully!");
            else
                Console.WriteLine("Failed! Customer not found or Account number already exists.");
        }

        private void UpdateAccountStatus()
        {
            Console.Write("Enter Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            Console.WriteLine("Select Status: 1. Active | 2. Frozen | 3. Closed");
            Console.Write("Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int statusInput) || statusInput < 1 || statusInput > 3)
            {
                Console.WriteLine("Invalid Status!");
                return;
            }

            AccountStatus status = (AccountStatus)statusInput;

            if (_bankService.ChangeAccountStatus(accNum, status))
                Console.WriteLine($"Status updated to {status}!");
            else
                Console.WriteLine("Account not found!");
        }

        private void ApplyInterest()
        {
            Console.Write("Enter Savings Account Number: ");
            if (!int.TryParse(Console.ReadLine(), out int accNum))
            {
                Console.WriteLine("Invalid account number!");
                return;
            }

            if (_bankService.ApplyInterestToSavings(accNum))
                Console.WriteLine("Interest applied successfully!");
            else
                Console.WriteLine("Failed! Account not found or it is not a Saving Account.");
        }
    }
}