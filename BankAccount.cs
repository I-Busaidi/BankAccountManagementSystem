using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    public class BankAccount
    {
        private string AccountNumber;
        private string AccountHolderName;
        public double Balance { get; private set; }

        public BankAccount()
        {
            Console.Clear();
            Console.WriteLine("\nEnter your account number: \n");
        }
        public BankAccount(string AccNumber, string AccHolderName)
        {
            AccountNumber = AccNumber;
            AccountHolderName = AccHolderName;
            Balance = 0;
        }
        public BankAccount(string AccNumber, string AccHolderName, double InitDepo = 0) 
        {
            AccountNumber=AccNumber;
            AccountHolderName = AccHolderName;
            Balance = InitDepo;
        }

        public void Deposit(double DepoAmount)
        {
            Balance += DepoAmount;
            Console.WriteLine($"\n${DepoAmount} has been successfully deposited to your account.\nNew balance is ${Balance}\n");
        }

        public void Withdraw(double DrawAmount)
        {
            if (Balance > DrawAmount)
            {
                Balance -= DrawAmount;
                Console.WriteLine($"\n${DrawAmount} has been successfully deposited to your account.\nNew balance is ${Balance}\n");
            }
            else
            {
                Console.WriteLine("\nInsufficient balance.\n");
            }
        }

        public string GetAccountInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Account Number: {AccountNumber}");
            sb.AppendLine($"Account Holder Name: {AccountHolderName}");
            sb.AppendLine($"Account Balance: ${Balance}");
            return sb.ToString();
        }

        public double GetBalance()
        {
            return Balance;
        }
        public string GetAccountHolderName()
        {
            return AccountHolderName;
        }
        public string GetAccountNumber()
        {
            return AccountNumber;
        }
    }
}
