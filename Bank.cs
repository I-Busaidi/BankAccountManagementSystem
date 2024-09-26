using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    public class Bank
    {
        public static List<BankAccount> BankAccounts = new List<BankAccount>();
        static Bank()
        {
            BankAccounts.Add(new BankAccount("444", "mmm", 0));
            BankAccounts.Add(new BankAccount("555", "ccc", 0));
            BankAccounts.Add(new BankAccount("999", "ddd", 8));
        }
        public void AddNewAccount(BankAccount UserInfo)
        {
            BankAccounts.Add(UserInfo);
        }
        public List<BankAccount> DisplayAllAccounts()
        {
            
            return new List<BankAccount> (BankAccounts);
        }
        public bool CheckAccountExist(string AccNumber, string AccHolderName)
        {
            bool AccExists = false;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                BankAccount acc = BankAccounts[i];
                if (acc.GetAccountNumber().Trim() == AccNumber.Trim() 
                    || acc.GetAccountHolderName().ToLower().Trim() == AccHolderName.ToLower().Trim())
                {
                    AccExists = true;
                    break;
                }
            }
            return AccExists;
        }
    }
}
