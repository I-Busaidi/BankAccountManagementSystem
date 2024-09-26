using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    public class Bank
    {
        public List<BankAccount> BankAccounts = new List<BankAccount>();

        public void AddNewAccount(BankAccount UserInfo)
        {
            BankAccounts.Add(UserInfo);
        }

        //public void GetAccByNumber(string AccNumber)
        //{
        //    for (int i = 0; i < BankAccounts.Count; i++)
        //    {
        //        BankAccount acc = BankAccounts[i];
        //        if (acc.GetAccountNumber().Trim() == AccNumber.Trim())
        //        {
        //            Console.WriteLine($"Account Number: {acc.GetAccountNumber()}\nAccount Holder Name: {acc.GetAccountHolderName}\nAccount Balance: ${acc.GetBalance}");
        //            break;
        //        }
        //    }
        //}

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
