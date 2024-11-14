namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public class GetLoan
	{
		private readonly LoanRepository _loanRepository;
		private readonly InstallmentRepository _installmentRepository;

		public GetLoan(RepositoryFactory repositoryFactory)
		{
			_loanRepository = repositoryFactory.CreateLoanRepository();
			_installmentRepository = repositoryFactory.CreateInstallmentRepository();
		}

		public GetLoanResponseDTO Execute(GetLoanRequestDTO input)
		{
			var loan = _loanRepository.GetById(input.LoanId);

			var installments = _installmentRepository.GetByLoanId(input.LoanId);

			return new GetLoanResponseDTO(loan.Amount, loan.Income, installments.Select(x => new InstallmentsResponseDTO(x.Number, x.Amount, x.Amortization, x.Interest, x.Balance)));
		}
	}

	public record GetLoanRequestDTO(Guid LoanId) { }
	public record GetLoanResponseDTO(decimal Amount, decimal Income, IEnumerable<InstallmentsResponseDTO> Installments) { }

	public record InstallmentsResponseDTO(int Number, decimal Amount, decimal Amortization, decimal Interest, decimal Balance) { }
}
