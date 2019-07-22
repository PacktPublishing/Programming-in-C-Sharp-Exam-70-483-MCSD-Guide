using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_3
{
    public class Account
    {
        public DateTime openingDate;
        public Customer customer;
        private float currentBalance;

        public bool OpenAccount(Customer customer)
        {
            this.openingDate = DateTime.Now.Date;
            this.currentBalance = 0.0f;
            this.customer = customer;
            if (VerifiyCustomerIdentity() && OpenAndLinkRelatedAccounts() && RetriveAndCountDeposit())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VerifiyCustomerIdentity()
        {
            //This function will verify the customer documents.
            return true;
        }

        private bool OpenAndLinkRelatedAccounts()
        {
            //This function will open the related accounts of savings , current and salary and link them together.
            return true;
        }

        private bool RetriveAndCountDeposit()
        {
            //This function will fetch the deposit, count and verify the amount.
            return true;
        }

        public bool DepositMoney(float deposit)
        {
            this.currentBalance = this.currentBalance + deposit;
            return true;
        }

        public bool WithdrawMoney(float withdraw)
        {
            if (this.currentBalance >= withdraw)
            {
                this.currentBalance = this.currentBalance - withdraw;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
