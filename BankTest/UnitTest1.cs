using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test Methods:
        /// Must be decorated with [TestMethod] attribute.
        /// Must return void
        /// Cannot have parameters
        /// </summary>

        [TestMethod]
        public void TestMethod1()
        {
        }

        //Test method regions
        #region Debit method tests
        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        //unit test method  
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // act
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // act
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception thrown.");
        }

        [TestMethod]
        public void Debit_WhenAccountIsFrozen_ShouldThrowException()
        {
            // arange
            double beginningBalance = 11.99;
            double debitAmount = 999.99;
            BankAccount account = new BankAccount("Mr. Octanonanonanonagon Smith", beginningBalance);
            account.ToggleFreeze();

            try
            {
                // act
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.AccountIsFrozenMessage);
                return;
            }
            Assert.Fail("No exception thrown.");
        }
        #endregion

        #region Credit method tests
        [TestMethod]
        public void Credit_WhenAccountIsFrozen_ShouldThrowException()
        {
            // arange
            double beginningBalance = 11.99;
            double creditAmount = 999.99;
            BankAccount account = new BankAccount("Mr. Octanonanonanonagon Smith", beginningBalance);
            account.ToggleFreeze();

            try
            {
                // act
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.AccountIsFrozenMessage);
                return;
            }
            Assert.Fail("No exception thrown.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // act
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
        #endregion
    }
}
