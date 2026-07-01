using System;
using BankSystem.Interfaces;

namespace BankSystem.UI
{
    public class BankMenu
    {
        private readonly IBankService _bankService;

        public BankMenu(IBankService bankService)
        {
            _bankService = bankService;
        }

        public void Display()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("======================================================");
                Console.WriteLine("\t\tWelcome To BANK SYSTEM\t\t");
                Console.WriteLine("======================================================\n");

                Console.WriteLine("1- Admin Login\n2- Customer Menu\n3- Exit");
                if (!int.TryParse(Console.ReadLine(), out int mainChoice))
                {
                    Console.WriteLine("Invalid input! Enter a valid number.");
                    continue;
                }

                switch (mainChoice)
                {
                    case 1:
                        AdminMenu adminMenu = new AdminMenu(_bankService);
                        adminMenu.Display();
                        break;
                    case 2:
                        CustomerMenu customerMenu = new CustomerMenu(_bankService);
                        customerMenu.Display();
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice! Choose between 1 and 3.");
                        break;
                }
            }
        }
    }
}