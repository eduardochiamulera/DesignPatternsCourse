namespace DesignPatterns.src.GOF.Behavioral.Command
{
	public class GetBalance
	{
		private readonly BankAccountRepository _bankAccountRepository;

		public GetBalance(BankAccountRepository bankAccountRepository)
		{
			_bankAccountRepository = bankAccountRepository;
		}

		public async Task<Output> ExecuteAsync(int bankAccountId)
		{
			var bankAccount = await _bankAccountRepository.GetByIdAsync(bankAccountId);

			return new Output(bankAccount.GetBalance());
		}
	}

	public record Output(decimal Balance);
}
