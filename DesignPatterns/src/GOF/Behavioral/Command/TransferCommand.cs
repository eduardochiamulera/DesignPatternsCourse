namespace DesignPatterns.src.GOF.Behavioral.Command
{
	public interface Command
	{
		Task ExecuteAsync();
	}

	public class TransferCommand : Command
	{
		public BankAccount From {  get; set; }
		public BankAccount To {  get; set; }

		public decimal Amount { get; set; }

        public TransferCommand(BankAccount from, BankAccount to, decimal amount)
        {
			From = from;
			To = to;
			Amount = amount;
            
        }

        public Task ExecuteAsync()
		{
			From.Debit(Amount);
			To.Credit(Amount);

			return Task.CompletedTask;
		}
	}
}
