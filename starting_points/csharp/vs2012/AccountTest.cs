using System;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class AccountTest
	{
		private IAccount account;
		private readonly Mock<DateTimeGenerator> dateTimeGeneratorMock = new Mock<DateTimeGenerator>();
		private readonly DateTime dateTimeOne = DateTime.Now;
		private readonly DateTime dateTimeTwo = DateTime.Now;

		[OneTimeSetUp]
		public void setup()
		{
			account = new Account(dateTimeGeneratorMock.Object);
			dateTimeGeneratorMock.SetupSequence(x => x.GetDateTime()).Returns(dateTimeOne).Returns(dateTimeTwo);
		}

		[Test]
		public void givenSomeDepositAndWrapShouldReturnStatement()
		{
			account.Deposit(500);
			account.WithDraw(100);

			Assert.AreEqual("Date        Amount  Balance\r\n"
				+ dateTimeOne.ToString("yyyy-MM-dd HH:mm:ss") + " 500 500\r\n"
				+ dateTimeTwo.ToString("yyyy-MM-dd HH:mm:ss") + " -100 400\r\n", account.PrintStatement());
		}

	}
}
