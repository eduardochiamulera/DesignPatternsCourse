namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface LoanRepository
	{
		void Save(Loan loan);
		Loan GetById(Guid loanId);
	}

	public class LoanRepositoryMemory : LoanRepository
	{
		private List<Loan> _loans;

		static LoanRepository _instance;

		private LoanRepositoryMemory()
		{
			_loans = [];
		}

		public IReadOnlyCollection<Loan> Loans => _loans;

		public Loan GetById(Guid loanId)
		{
			var loan = _loans.Find(x => x.LoanId == loanId);

			if (loan == null)
			{
				throw new KeyNotFoundException("Loan not foud.");
			}

			return loan;
		}

		public void Save(Loan loan)
		{
			_loans.Add(loan);
		}

		public static LoanRepository GetInstance()
		{
			if(_instance == null)
			{
				_instance = new LoanRepositoryMemory();
			}

			return _instance;
		}
	}
}
