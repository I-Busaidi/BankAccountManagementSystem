
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccountManagementSystem
{
    internal class Program
    {
        private static Bank bank = new Bank();

        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            string Menu = "Welcome to Codeline Bank!\n\n" +
                          "Choose an option:\n\n" +
                          "1. Add Account.\n" +
                          "2. Deposit.\n" +
                          "3. Withdraw.\n" +
                          "4. View Account by Account Number.\n" +
                          "5. Display All Accounts.\n" +
                          "\n0. Exit.";

            bool StopApp = false;

            do
            {
                Console.Clear();
                Console.WriteLine(Menu);
                int Choice;

                while (!int.TryParse(Console.ReadLine(), out Choice) || Choice > 5 || Choice < 0)
                {
                    Console.Clear();
                    Console.WriteLine(Menu);
                    Console.WriteLine("\n\nInvalid input, please try again:\n");
                }
                Console.Clear();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Exiting the Bank Application...");
                        StopApp = true;
                        break;
                    case 1:
                        AddAccount();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        ViewByAccNumber();
                        break;
                    case 5:
                        DisplayAllAcc();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Input...\n");
                        break;
                }

                if (!StopApp)
                {
                    Console.WriteLine("\n\nPress any Key to Continue...");
                    Console.ReadKey();
                }
            } while (!StopApp);
        }

        static void AddAccount()
        {
            string AccNumber;
            string AccHolderName;
            double InitDepo = 0;
            int InitDepoChoice;

            Console.WriteLine("\nEnter account number: \n");
            while (string.IsNullOrEmpty(AccNumber = Console.ReadLine()) || !ValidateAccountInfo(AccNumber, 1).Item1 || !double.TryParse(AccNumber, out _))
            {
                Console.Clear();
                Console.WriteLine("\nEnter account number: \n");
                Console.WriteLine(ValidateAccountInfo(AccNumber, 1).Item2);
                Console.WriteLine("\nInvalid input, please try again:\n");
            }

            Console.Clear();
            Console.WriteLine("\nEnter account holder name: \n");
            while (string.IsNullOrEmpty(AccHolderName = Console.ReadLine()) || !ValidateAccountInfo(AccHolderName, 2).Item1 || double.TryParse(AccHolderName, out _))
            {
                Console.Clear();
                Console.WriteLine("\nEnter account holder name: \n");
                Console.WriteLine(ValidateAccountInfo(AccHolderName, 2).Item2);
                Console.WriteLine("\nInvalid input, please try again:\n");
            }

            Console.Clear();
            Console.WriteLine("\nMake an initial deposit? (1)Yes | (2)No\n");
            while (!int.TryParse(Console.ReadLine(), out InitDepoChoice) || (InitDepoChoice > 2) || (InitDepoChoice < 1))
            {
                Console.Clear();
                Console.WriteLine("\nMake an initial deposit? (1)Yes | (2)No\n");
                Console.WriteLine("\nInvalid input, please try again:\n");
            }

            if (InitDepoChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("\nEnter the amount to deposit:\n");

                while (!double.TryParse(Console.ReadLine(), out InitDepo) || InitDepo < 1)
                {
                    Console.Clear();
                    Console.WriteLine("\nEnter the amount to deposit:\n");
                    Console.WriteLine("\nInvalid input, please try again:\n");
                }
            }

            Console.Clear();
            if (InitDepo > 0)
            {
                bank.AddNewAccount(new BankAccount(AccNumber, AccHolderName, InitDepo));
            }
            else
            {
                bank.AddNewAccount(new BankAccount(AccNumber, AccHolderName));
            }
            Console.WriteLine("\nAccount has been created successfully.");
        }

        static void Deposit()
        {
            string AccNumber;
            double DepoAmount;

            Console.WriteLine("\nEnter your account number: \n");
            AccNumber = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the amount to deposit: \n");
            while (!double.TryParse(Console.ReadLine(), out DepoAmount) || DepoAmount < 1)
            {
                Console.Clear();
                Console.WriteLine("Enter the amount to deposit: \n");
                Console.WriteLine("\nInvalid input, please try again: \n");
            }

            var Accounts = bank.DisplayAllAccounts();
            bool AccFound = false;
            foreach (var account in Accounts)
            {
                if (account.GetAccountNumber().Trim() == AccNumber.Trim())
                {
                    account.Deposit(DepoAmount);
                    AccFound = true;
                    break;
                }
            }

            if (!AccFound)
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void Withdraw()
        {
            string AccNumber;
            double DrawAmount;

            Console.WriteLine("\nEnter your account number: \n");
            AccNumber = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter the amount to withdraw: \n");
            while (!double.TryParse(Console.ReadLine(), out DrawAmount) || DrawAmount < 1)
            {
                Console.Clear();
                Console.WriteLine("Enter the amount to withdraw: \n");
                Console.WriteLine("\nInvalid input, please try again: \n");
            }

            var Accounts = bank.DisplayAllAccounts();
            bool AccFound = false;
            foreach (var account in Accounts)
            {
                if (account.GetAccountNumber().Trim() == AccNumber.Trim())
                {
                    account.Withdraw(DrawAmount);
                    AccFound = true;
                    break;
                }
            }

            if (!AccFound)
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void ViewByAccNumber()
        {
            Console.WriteLine("\nEnter your account number: \n");
            string AccNumber = Console.ReadLine();
            bool AccFound = false;
            var Accounts = bank.DisplayAllAccounts();

            foreach ( var account in Accounts )
            {
                if (account.GetAccountNumber().Trim() == AccNumber.Trim())
                {
                    Console.WriteLine(account.GetAccountInfo());
                    AccFound = true;
                    break;
                }
            }

            if (!AccFound)
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void DisplayAllAcc()
        {
            List<BankAccount> Accounts = bank.DisplayAllAccounts();
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{"Account Number",-30} | {"Account Holder Name",-30} | {"Balance",-30}");
            string border = new string('-', 100);
            sb.AppendLine(border);
            foreach (var account in Accounts)
            {
                sb.AppendLine($"{account.GetAccountNumber(),-30} | {account.GetAccountHolderName(),-30} | ${account.GetBalance(),-30}");
            }
            Console.WriteLine(sb.ToString());
        }

        static (bool, string?) ValidateAccountInfo(string Input, int opt = 1)
        {
            bool AccNumFound = false;
            bool AccNameFound = false;
            string? Message = null;

            var Accounts = bank.DisplayAllAccounts();

            foreach (var account in Accounts)
            {
                if (account.GetAccountNumber().Trim() == Input.Trim())
                {
                    AccNumFound = true;
                    break;
                }
                if (account.GetAccountHolderName().Trim().ToLower() == Input.Trim().ToLower())
                {
                    AccNameFound = true;
                    break;
                }
            }
            if (opt == 1)
            {
                if (AccNumFound)
                {
                    Message = "\nAccount number already exists.";
                }
                return (AccNameFound, Message);
            }
            else
            {
                if (AccNameFound)
                {
                    Message = "\nAccount holder name already exists.";
                }
                return (AccNumFound, Message);
            }
        }
    }
}
