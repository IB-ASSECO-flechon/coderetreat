using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
	public class Account : IAccount
	{
		private DateTimeGenerator dateTimeGenerator;
		private IDictionary<DateTime, int> balance = new Dictionary<DateTime, int>();

		public Account(DateTimeGenerator dateTimeGenerator)
		{
			this.dateTimeGenerator = dateTimeGenerator;
		}

		private static readonly Account instance = new Account(new DateTimeGenerator());

		public static IAccount Instance => instance;

		public void Deposit(int amount)
		{
			this.balance.Add(dateTimeGenerator.GetDateTime(), amount);
		}

		public string PrintStatement()
		{
			int balance = 0;
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Date        Amount  Balance");
			foreach (DateTime key in this.balance.Keys)
			{
				int amount = this.balance[key];
				balance += amount;
				builder.AppendLine(key.ToString("yyyy-MM-dd HH:mm:ss") + " " + amount.ToString() + " " + balance);
			}
			return builder.ToString();
		}

		public void WithDraw(int amount)
		{
			this.balance.Add(dateTimeGenerator.GetDateTime(), amount * -1);
		}
	}
}
