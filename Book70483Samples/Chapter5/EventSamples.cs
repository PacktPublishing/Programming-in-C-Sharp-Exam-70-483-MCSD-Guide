using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    public class EventSamples
    {
        private void NotifyCustomer(object sender, TransactionEventArgs e)
        {
            Console.WriteLine("Your Account is {0} for Rs.{1} ", e.TranactionType, e.TranactionAmount);
        }
        public void Run()
        {
            Account MyAccount = new Account();

            MyAccount.ProcessTransaction += new TransactionHandler(NotifyCustomer);
            MyAccount.SetInitialDeposit(5000);
            MyAccount.ShowBalance();
            MyAccount.Credit(500);
            MyAccount.ShowBalance();
            MyAccount.Debit(500);
            MyAccount.ShowBalance();
        }
    }

    public delegate void TransactionHandler(object sender, TransactionEventArgs e); // Delegate Definition 
    class Account
    {
        public event TransactionHandler ProcessTransaction; // Event Definition
        public int BalanceAmount;
        public void SetInitialDeposit(int amount)
        {
            this.BalanceAmount = amount;
            TransactionEventArgs e = new TransactionEventArgs(amount, "InitialBalance");
            OnProcessTransaction(e); // InitialBalance transaction made 
        }
        public void Debit(int debitAmount)
        {
            if (debitAmount < BalanceAmount)
            {
                BalanceAmount = BalanceAmount - debitAmount;
                TransactionEventArgs e = new TransactionEventArgs(debitAmount, "Debited");
                OnProcessTransaction(e); // Debit transaction made 
            }
        }
        public void Credit(int creditAmount)
        {
            BalanceAmount = BalanceAmount + creditAmount;
            TransactionEventArgs e = new TransactionEventArgs(creditAmount, "Credited");
            OnProcessTransaction(e); // Credit transaction made
        }

        public void ShowBalance()
        {
            TransactionEventArgs e = new TransactionEventArgs(BalanceAmount, "Total Balance");
            OnProcessTransaction(e); // Credit transaction made
        }
        protected virtual void OnProcessTransaction(TransactionEventArgs e)
        {
            ProcessTransaction?.Invoke(this, e);
        }
    }

    public class TransactionEventArgs : EventArgs
    {
        private int _transactionAmount;
        private string _transactionType;
        public TransactionEventArgs(int amt, string type)
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
