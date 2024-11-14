namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public class ApplyForLoan
	{
		private readonly LoanRepository _loanRepository;
		private readonly InstallmentRepository _installmentRepository;
		private readonly LoanFactory _loanFactory;

		public ApplyForLoan(RepositoryFactory repositoryFactory, LoanFactory loanFactory)
		{
			_loanRepository = repositoryFactory.CreateLoanRepository();
			_installmentRepository = repositoryFactory.CreateInstallmentRepository();
			_loanFactory = loanFactory;
		}

		public ApplyForLoanResponseDTO Execute(ApplyForLoanRequestDTO input)
		{
			var loan = _loanFactory.Create(input.Amount, input.Income, input.Installments);
			var installmentCalculator = _loanFactory.CreateInstallmentCalculator();
			var installments = installmentCalculator.Calculate(loan);

			_loanRepository.Save(loan);

			foreach (var installment in installments)
			{
				_installmentRepository.Save(installment);
			}

			return new ApplyForLoanResponseDTO(loan.LoanId);
		}
	}

	public record ApplyForLoanRequestDTO(decimal Amount, decimal Income, int Installments) { }
	public record ApplyForLoanResponseDTO(Guid LoanId) { }
}
