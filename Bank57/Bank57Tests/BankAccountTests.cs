/*using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank57Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}*/
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank57Tests
{
    [TestClass]
    public class BankAccountTests
    {
        /*
        [TestMethod]
        public void TestMethod1()
        {
        }
        */

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance57()
        {
            // Arrange
            double beginningBalance57 = 11.99;
            double debitAmount57 = 4.55;
            double expected57 = 7.44;
            BankAccount57 account57 = new BankAccount57("Mr. Bryan Walton", beginningBalance57);

            // Act
            account57.Debit57(debitAmount57);

            // Assert
            double actual57 = account57.Balance57;
            Assert.AreEqual(expected57, actual57, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange57()
        {
            // Arrange
            double beginningBalance57 = 11.99;
            double debitAmount57 = -100.00;
            BankAccount57 account = new BankAccount57("Mr. Bryan Walton", beginningBalance57);

            // Act and assert
            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit57(debitAmount57));

            // Act
            try
            {
                account.Debit57(debitAmount57);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount57.DebitAmountLessThanZeroMessage57);
            }
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange57()
        {
            // Arrange
            double beginningBalance57 = 11.99;
            double debitAmount57 = 100.00;
            BankAccount57 account = new BankAccount57("Mr. Bryan Walton", beginningBalance57);

            // Act and assert
            //Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit57(debitAmount57));

            // Act
            try
            {
                account.Debit57(debitAmount57);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount57.DebitAmountExceedsBalanceMessage57);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}