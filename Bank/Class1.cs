using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{
    /// <summary>  
    /// Bank Account demo class.  
    /// </summary>  
    public class BankAccount
    {
        // class under test  
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";
        public const string AccountIsFrozenMessage = "Account is frozen";
        public const string CreditAmountLessThanZeroMessage = "Credit amount less than zero";

        private string m_customerName;

        private double m_balance;

        private bool m_frozen = false;

        #region Constructors
        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        #endregion

        #region CustomerName, Balance accessors
        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        #endregion

        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new ArgumentOutOfRangeException(AccountIsFrozenMessage);
            }

            // new exception information
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // corrected code
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new ArgumentOutOfRangeException(AccountIsFrozenMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }

            m_balance += amount;
        }

        #region Freeze account toggle methods
        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }
        #endregion

        #region for testing purposes
        public void ToggleFreeze()

        {

            m_frozen = !m_frozen;

        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
        #endregion
    }
}
