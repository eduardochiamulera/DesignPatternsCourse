namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface RepositoryFactory
	{
		LoanRepository CreateLoanRepository();
		InstallmentRepository CreateInstallmentRepository();
	}

	public class RepositoryMemoryFactory : RepositoryFactory
	{
		public InstallmentRepository CreateInstallmentRepository()
		{
			return InstallmentRepositoryMemory.GetInstance();
		}

		public LoanRepository CreateLoanRepository()
		{
			return LoanRepositoryMemory.GetInstance();
		}
	}
}
