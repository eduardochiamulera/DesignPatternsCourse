namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface LoanFactoryProvider
	{
		LoanFactory Create(LoanType type);
	}

	public class LoanFactoryMemoryProvider : LoanFactoryProvider
	{
		public LoanFactory Create(LoanType type)
		{

			return type switch
			{
				LoanType.Car => new CarLoanFactory(),
				LoanType.Mortgage => new MortgageLoanFactory(),
				_ => throw new ArgumentException("Invalid type")
			};
		}
	}

	public enum LoanType
	{
		Car,
		Mortgage
	}
}
