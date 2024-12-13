namespace DesignPatterns.src.GOF.Behavioral.Command
{

	public class BankAccount
	{
		public int Id { get; set; }
		public List<Transaction> Transactions { get; set; }

        public BankAccount(int id)
        {
			Id = id;
            Transactions = new List<Transaction>();
        }

        public void Debit(decimal amount)
        {
			Transactions.Add(new Transaction("debit", amount));
        }
		public void Credit(decimal amount)
		{
			Transactions.Add(new Transaction("credit", amount));
		}

		public decimal GetBalance()
		{
			decimal total = 0;

			foreach (var item in Transactions)
			{
				if(item.Type == "debit")
				{
					total -= item.Amount;
				}

				if (item.Type == "credit")
				{
					total += item.Amount;
				}
			}

			return total;
		}
	}
}
