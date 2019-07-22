using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class Account
    {
        private readonly object AcountBalLock = new object();
        private decimal balanceamount;

        public Account(decimal initialBalance)
        {
            balanceamount = initialBalance;
        }

        public decimal Debit(decimal amount)
        {
            lock (AcountBalLock)
            {
                if (balanceamount >= amount)
                {
                    Console.WriteLine($"Balance before debit :{balanceamount,5}");
                    Console.WriteLine($"Amount to debit     :{amount,5}");
                    balanceamount = balanceamount - amount;
                    Console.WriteLine($"Balance after debit  :{balanceamount,5}");
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Credit(decimal amount)
        {
            lock (AcountBalLock)
            {
                Console.WriteLine($"Balance before credit:{balanceamount,5}");
                Console.WriteLine($"Amount to credit        :{amount,5}");
                balanceamount = balanceamount + amount;
                Console.WriteLine($"Balance after credit :{balanceamount,5}");
            }
        }
    }
}
