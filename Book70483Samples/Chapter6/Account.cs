using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter6
{
    internal class BankAcc
    {
        private readonly object AcountBalLock = new object();
        private decimal balanceamount;

        public BankAcc(decimal iBal)
        {
            balanceamount = iBal;
        }

        public decimal Debit(decimal amt)
        {
            lock (AcountBalLock)
            {
                if (balanceamount >= amt)
                {
                    Console.WriteLine($"Balance before debit :{balanceamount,5}");
                    Console.WriteLine($"Amount to debit     :{amt,5}");
                    balanceamount = balanceamount - amt;
                    Console.WriteLine($"Balance after debit  :{balanceamount,5}");
                    return amt;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Credit(decimal amt)
        {
            lock (AcountBalLock)
            {
                Console.WriteLine($"Balance before credit:{balanceamount,5}");
                Console.WriteLine($"Amount to credit        :{amt,5}");
                balanceamount = balanceamount + amt;
                Console.WriteLine($"Balance after credit :{balanceamount,5}");
            }
        }
    }
}
