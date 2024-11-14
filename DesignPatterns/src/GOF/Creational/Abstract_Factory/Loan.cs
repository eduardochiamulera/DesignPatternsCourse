namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public abstract class Loan
	{
		protected Loan(Guid loanId, decimal amount, decimal income, decimal installments, string type)
		{
			LoanId = loanId;
			Amount = amount;
			Income = income;
			Installments = installments;
			Type = type;
		}

		protected static Loan Create(decimal amount, decimal income, decimal installments)
		{
			throw new Exception("This method is abstract");
		}

		public abstract decimal Rate { get; protected set; }

		public Guid LoanId { get; protected set; }
		public decimal Amount { get; protected set; }
		public decimal Income { get; protected set; }
		public decimal Installments { get; protected set; }
		public string Type { get; protected set; }
        
    }

	public class MortgageLoan : Loan
	{
		public MortgageLoan(Guid LoanId, decimal amount, decimal income, decimal installments) 
			: base(LoanId, amount, income, installments, "Mortgage")
		{
			if( installments > 420)
			{
				throw new Exception("The maximum number of installments for mortgage loan is 420.");
			}

			if (income * 0.25m < amount / installments)
			{
				throw new Exception("The installment amount could not exceed 25% of monthly income.");
			}
		}

		public override decimal Rate { get; protected set; } = 10M;

		public static new Loan Create(decimal amount, decimal income, decimal installments)
		{
			return new MortgageLoan(Guid.NewGuid(), amount, income, installments);
		}
	}


	public class CarLoan : Loan
	{
		public CarLoan(Guid LoanId, decimal amount, decimal income, decimal installments)
			: base(LoanId, amount, income, installments, "Car")
		{
			if (installments > 60)
			{
				throw new Exception("The maximum number of installments for car loan is 60.");
			}

			if (income * 0.30m < amount / installments)
			{
				throw new Exception("The installment amount could not exceed 30% of monthly income.");
			}
		}

		public override decimal Rate { get; protected set; } = 15M;

		public static new Loan Create(decimal amount, decimal income, decimal installments)
		{
			return new CarLoan(Guid.NewGuid(), amount, income, installments);
		}
	}
}
