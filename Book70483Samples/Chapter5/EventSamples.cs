using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    public class EventSamples
    {
        private void AlertCustomer(object sender, BankTransEventArgs e)
        {
            Console.WriteLine("Your Account is {0} for Rs.{1} ", e.TranactionType, e.TranactionAmount);
        }
        public void Run()
        {
            Account bankAccount = new Account();

            bankAccount.ProcessTransaction += new BankTransHandler(AlertCustomer);
            bankAccount.SetInitialDeposit(5000);
            bankAccount.ShowBalance();
            bankAccount.Credit(500);
            bankAccount.ShowBalance();
            bankAccount.Debit(500);
            bankAccount.ShowBalance();
        }
    }

    public delegate void BankTransHandler(object sender, BankTransEventArgs e); // Delegate Definition 
    class Account
    {
        public event BankTransHandler ProcessTransaction; // Event Definition
        public int BALAmount;
        public void SetInitialDeposit(int amount)
        {
            this.BALAmount = amount;
            BankTransEventArgs e = new BankTransEventArgs(amount, "InitialBalance");
            OnProcessTransaction(e); // InitialBalance transaction made 
        }
        public void Debit(int debitAmount)
        {
            if (debitAmount < BALAmount)
            {
                BALAmount = BALAmount - debitAmount;
                BankTransEventArgs e = new BankTransEventArgs(debitAmount, "Debited");
                OnProcessTransaction(e); // Debit transaction made 
            }
        }
        public void Credit(int creditAmount)
        {
            BALAmount = BALAmount + creditAmount;
            BankTransEventArgs e = new BankTransEventArgs(creditAmount, "Credited");
            OnProcessTransaction(e); // Credit transaction made
        }

        public void ShowBalance()
        {
            BankTransEventArgs e = new BankTransEventArgs(BALAmount, "Total Balance");
            OnProcessTransaction(e); // Credit transaction made
        }
        protected virtual void OnProcessTransaction(BankTransEventArgs e)
        {
            ProcessTransaction?.Invoke(this, e);
        }
    }

    public class BankTransEventArgs : EventArgs
    {
        private int _transactionAmount;
        private string _transactionType;
        public BankTransEventArgs(int amt, string type)
        {
            this._transactionAmount = amt;
            this._transactionType = type;
        }
        public int TranactionAmount
        {
            get
            {
                return _transactionAmount;
            }
        }
        public string TranactionType
        {
            get
            {
                return _transactionType;
            }
        }
    }
}
