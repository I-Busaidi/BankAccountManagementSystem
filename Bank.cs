using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    public class Bank
    {
        private List<(string AccNumber, string AccHolderName, double Balance)> BankAccounts = new List<(string AccNumber, string AccHolderName, double Balance)>();

        public bool CheckExistingAcc(string AccNumber, string AccHolderName)
        {
            bool AccExists = false;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                if ((BankAccounts[i].AccNumber.Trim() == AccNumber.Trim()) || (BankAccounts[i].AccHolderName.Trim().ToLower() == AccHolderName.Trim().ToLower()))
                {
                    AccExists = true;
                }
            }
            return AccExists;
        }

        public void AddNewAccount(string AccNumber, string AccHolderName, double Balance)
        {
            BankAccounts.Add((AccNumber, AccHolderName, Balance));
        }

        public void GetAccByNumber(string AccNumber)
        {
            for (int i = 0;i < BankAccounts.Count;i++)
            {
                if (BankAccounts[i].AccNumber.Trim() == AccNumber.Trim())
                {
                    Console.WriteLine($"Bank Account Number: {BankAccounts[i].AccNumber}\n" +
                        $"Bank Account Holder Name: {BankAccounts[i].AccHolderName}.\n" +
                        $"Bank Account Balance: ${BankAccounts[i].Balance}\n");
                    break;
                }
            }
        }

        public void DisplayAllAccounts()
        {
            StringBuilder sb = new StringBuilder();
            string border = new string('-', 100);
            sb.AppendLine($"{"Account Number", 30} | {"Account Holder Name", 30} | {"Balance", 30}");
            for (int i = 0; i < BankAccounts.Count ; i++)
            {
                sb.AppendLine($"{"",30} | {"",30} | {"",30}");
                sb.AppendLine($"{BankAccounts[i].AccNumber,30} | {BankAccounts[i].AccHolderName,30} | {BankAccounts[i].Balance,30}");
            }
            Console.WriteLine( sb.ToString() );
            sb.Clear();
        }

        public bool CheckWithdrawPossible(string AccNumber, double WithdrawAmount)
        {
            bool CanWithdraw = false;
            for (int i = 0; i < BankAccounts.Count; i++)
            {
                if (BankAccounts[i].AccNumber == AccNumber)
                {
                    if (BankAccounts[i].Balance >= WithdrawAmount)
                    {
                        CanWithdraw = true;
                    }
                    break;
                }
            }
            return CanWithdraw;
        }

        public void ChangeBalance(string AccNumber, double BalanceChange)
        {
            for (int i = 0;i < BankAccounts.Count;i++)
            {
                if (BankAccounts[i].AccNumber.Trim() == AccNumber.Trim())
                {
                    BankAccounts[i] = (BankAccounts[i].AccNumber, BankAccounts[i].AccHolderName, (BankAccounts[i].Balance + BalanceChange));
                    break;
                }
            }
        }
    }
}
