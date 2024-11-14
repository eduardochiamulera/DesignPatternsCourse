namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface LoanFactory
	{
		Loan Create(decimal amount, decimal income, int installments);
		InstallmentCalculator CreateInstallmentCalculator();
	}

	public class MortgageLoanFactory : LoanFactory
	{
		public Loan Create(decimal amount, decimal income, int installments)
		{
			return MortgageLoan.Create(amount, income, installments);
		}

		public InstallmentCalculator CreateInstallmentCalculator()
		{
			return new SACInstallmentCalculator();
		}
	}

	public class CarLoanFactory : LoanFactory
	{
		public Loan Create(decimal amount, decimal income, int installments)
		{
			return CarLoan.Create(amount, income, installments);
		}

		public InstallmentCalculator CreateInstallmentCalculator()
		{
			return new PriceInstallmentCalculator();
		}
	}
}
