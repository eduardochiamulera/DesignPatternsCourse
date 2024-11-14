namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface InstallmentRepository
	{
		void Save(Installment installment);
		IEnumerable<Installment> GetByLoanId(Guid loanId);
	}

	public class InstallmentRepositoryMemory : InstallmentRepository
	{
		private List<Installment> _installments;

		static InstallmentRepository _instance;
		private InstallmentRepositoryMemory()
		{
			_installments = [];
		}

		public IReadOnlyCollection<Installment> Installments => _installments;

		public IEnumerable<Installment> GetByLoanId(Guid loanId)
		{
			return _installments.Where(x => x.LoanId == loanId);
		}

		public void Save(Installment installment)
		{
			_installments.Add(installment);
		}

		public static InstallmentRepository GetInstance() 
		{ 
			if( _instance == null)
			{
				_instance = new InstallmentRepositoryMemory();
			}

			return _instance;
		}
	}
}
