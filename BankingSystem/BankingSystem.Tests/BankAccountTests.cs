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
                int id = 123;
                decimal amount = 500;
                BankAccount bankAccount = new BankAccount(id,amount);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount+amount, bankAccount.Balance,"Balance increase with positive number");
            }
        }
        [TestCase(123,500)]
        [TestCase(123, 500.6789)]
        [TestCase(123, 0)]
        public void ConstructorShouldIncreaseBalanceCorrectly(int id ,decimal amount)
        {
            {
                //Arrange
                BankAccount bankAccount = new BankAccount(id, amount);
         
                //Assert
                Assert.AreEqual( amount, bankAccount.Balance);
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
        public void BalanceShouldThrowArgumentExeptionWhenAmountIsNegative()
        {
            {
                //Arrange
                int id = 123;
                decimal amount = -100;
                

                //Act
                
                //Assert
                Assert.Throws<ArgumentException>(() =>
                                  new BankAccount(id, amount));
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
        [TestCase(123,500)]
        [TestCase(123,1000)]
        public void BalanceShouldIncreseBalanceWhenBalanceIsLessOrEqual1000(int id ,decimal balance)
        {
            BankAccount bankAccount = new BankAccount(id, balance);
            bankAccount.Bonus();
            Assert.AreEqual(balance, bankAccount.Balance);
        }
        [TestCase(123, 1100)]
        [TestCase(123, 1999.9999)]
        public void BalanceShouldIncreseBalanceWhenBalanceIsBetween1000And2000(int id, decimal balance)
        {
            BankAccount bankAccount = new BankAccount(id, balance);
            var expectedResult = balance + 100;
            bankAccount.Bonus();
            Assert.AreEqual(expectedResult, bankAccount.Balance);
        }


    }
}