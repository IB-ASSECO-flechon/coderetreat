namespace Tests
{
	public interface IAccount
	{
		void Deposit(int amount);
		void WithDraw(int draw);
		string PrintStatement();
	}
}
