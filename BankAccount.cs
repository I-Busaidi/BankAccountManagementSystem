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
        private double Balance;

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

        public void Deposit(double DepoAmount)
        {

        }

        public void Withdraw(double DrawAmount)
        {

        }

        public string GetAccountInfo()
        {
            StringBuilder sb = new StringBuilder();

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
