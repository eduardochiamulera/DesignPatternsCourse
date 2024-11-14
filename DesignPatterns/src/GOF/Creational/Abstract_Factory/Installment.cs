namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public class Installment
	{
		public Installment(Guid loanId, int number, decimal amount, decimal amortization, decimal interest, decimal balance)
		{
			LoanId = loanId;
			Number = number;
			Amount = amount;
			Amortization = amortization;
			Interest = interest;
			Balance = balance;
		}

		public Guid LoanId { get; set; }
		public int Number { get; set; }
		public decimal Amount { get; set; }
		public decimal Amortization { get; set; }
        public decimal Interest { get; set; }
        public decimal Balance { get; set; }
    }
}