/*using System;

namespace Bank57
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
*/

using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount57
    {
        private readonly string m_customerName57;
        private double m_balance57;
        public const string DebitAmountExceedsBalanceMessage57 = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage57 = "Debit amount is less than zero";

        private BankAccount57() { }

        public BankAccount57(string customerName57, double balance57)
        {
            m_customerName57 = customerName57;
            m_balance57 = balance57;
        }

        public string CustomerName57
        {
            get { return m_customerName57; }
        }

        public double Balance57
        {
            get { return m_balance57; }
        }

        public void Debit57(double amount57)
        {
            if (amount57 > m_balance57)
            {
                //throw new ArgumentOutOfRangeException("amount");
                throw new System.ArgumentOutOfRangeException("amount", amount57, DebitAmountExceedsBalanceMessage57);
            }

            if (amount57 < 0)
            {
                //throw new ArgumentOutOfRangeException("amount");
                throw new System.ArgumentOutOfRangeException("amount", amount57, DebitAmountLessThanZeroMessage57);
            }

            m_balance57 -= amount57; // intentionally incorrect code
        }

        public void Credit57(double amount57)
        {
            if (amount57 < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance57 += amount57;
        }

        public static void Main()
        {
            BankAccount57 ba57 = new BankAccount57("Mr. Bryan Walton", 11.99);

            ba57.Credit57(5.77);
            ba57.Debit57(11.22);
            Console.WriteLine("Current balance is ${0}", ba57.Balance57);
        }
    }
}