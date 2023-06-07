using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class AccountTest
	{
		private IAccount account;
		private readonly Mock<DateTimeGenerator> dateTimeGeneratorMock = new Mock<DateTimeGenerator>();
		private readonly DateTime dateTime = DateTime.Now;

		[TestInitialize]
		public void setup()
		{
			account = new Account(dateTimeGeneratorMock.Object);
			dateTimeGeneratorMock.Setup(x => x.GetDateTime()).Returns(dateTime);

		}

		[TestMethod]
		public void givenSomeDepositAndWrapShouldReturnStatement()
		{
			account.Deposit(500);
			account.WithDraw(100);

			Assert.AreEqual("Date        Amount  Balance\r\n"
				+ dateTime.ToString("yyyy-MM-dd") + " 500 500\r\n"
				+ dateTime.ToString("yyyy-MM-dd") + " -100 400\r\n", account.PrintStatement());
		}
	}
}
