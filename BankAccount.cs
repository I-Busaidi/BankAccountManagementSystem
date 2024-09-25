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

        }
        public BankAccount(string AccNumber, string AccHolderName, decimal InitDepo) 
        {
            
        }

        public void Deposit(double DepoAmount)
        {

        }

        public void Withdraw(double DrawAmount)
        {

        }

        public string GetAccountNumber()
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
