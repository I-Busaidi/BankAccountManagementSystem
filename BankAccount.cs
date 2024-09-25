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

        public BankAccount(string AccNumber, string AccHolderName)
        {
            AccountNumber = AccNumber;
            AccountHolderName = AccHolderName;
            Balance = 0;
        }
        public BankAccount(string AccNumber, string AccHolderName, double InitDepo) 
        {
            AccountNumber=AccNumber;
            AccountHolderName = AccHolderName;
            Balance = InitDepo;
        }

        public void Deposit(double DepoAmount, string AccNumber)
        {
            Bank bank = new Bank();
            for (int i = 0; i < bank.BankAccounts.Count; i++)
            {
                if (bank.BankAccounts[i].AccountNumber.Trim() == AccNumber.Trim())
                {
                    bank.BankAccounts[i] = new BankAccount(bank.BankAccounts[i].AccountNumber, bank.BankAccounts[i].AccountHolderName, bank.BankAccounts[i].Balance + DepoAmount);
                    Console.WriteLine($"\n${DepoAmount} has been successfully deposited to your account.\nNew balance is ${bank.BankAccounts[i].Balance}\n");
                }
            }
        }

        public void Withdraw(double DrawAmount, string AccNumber)
        {
            Bank bank = new Bank();
            for (int i = 0; i < bank.BankAccounts.Count; i++)
            {
                if (bank.BankAccounts[i].AccountNumber.Trim() == AccNumber.Trim())
                {
                    if (bank.BankAccounts[i].Balance >= DrawAmount)
                    {
                        bank.BankAccounts[i] = new BankAccount(bank.BankAccounts[i].AccountNumber, bank.BankAccounts[i].AccountHolderName, bank.BankAccounts[i].Balance - DrawAmount);
                        Console.WriteLine($"\n${DrawAmount} has been successfully withdrawn from you account.\nNew balance is ${bank.BankAccounts[i].Balance}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nInsufficient balance.\n");
                    }
                    break;
                }
            }
        }

        public string GetAccountInfo(string AccNumber)
        {
            StringBuilder sb = new StringBuilder();
            Bank bank = new Bank();
            for (int i = 0; i < bank.BankAccounts.Count; i++)
            {
                if (bank.BankAccounts[i].AccountNumber.Trim() == AccNumber.Trim())
                {
                    Console.WriteLine($"Account Number: {bank.BankAccounts[i].AccountNumber}\nAccount Holder Name: {bank.BankAccounts[i].AccountHolderName}\nAccount Balance: ${bank.BankAccounts[i].Balance}");
                    break;
                }
            }
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
