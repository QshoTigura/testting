using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    [TestFixture]
    public class BankAccountTests
    {

        [Test]
        public void DepositShouldIncreaseBalanceWhenBalanceIsZero()
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount, bankAccount.Balance,"Balance increase with positive number");
            }
        }

        [Test]
        public void AccountInicializeWhithPositiveValue()
        {
            {
                //Arrange 

                //Act
                BankAccount bankAccount = new BankAccount(123, 2000m);

                //Assert
                Assert.AreEqual(2000m, bankAccount.Balance);
            }
        }

        
        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptions()
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                //Act
                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                                  bankAccount.Deposit(depositAmount));
            }
        }

        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount(123);
            decimal depositAmount = -100;

            //Act
            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
                                    bankAccount.Deposit(depositAmount));

            Assert.AreEqual(ex.Message, "Negative amount");
        }

        
    }
}