namespace DesignPatterns.src.GOF.Behavioral.Command
{
	public class Transaction
	{
		public Transaction(string type, decimal amount)
		{
			Type = type;
			Amount = amount;
		}

		public string Type { get; set; }
		public decimal Amount { get; set; }
	}
}
