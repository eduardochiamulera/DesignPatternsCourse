namespace DesignPatterns.src.GOF.Behavioral.Command
{
	public class MakeTransfer
	{
		private readonly BankAccountRepository _bankAccountRepository;

        public MakeTransfer(BankAccountRepository bankAccountRepository)
        {
			_bankAccountRepository = bankAccountRepository;
		}

		public async Task ExecuteAsync(Input input)
		{
			var from = await _bankAccountRepository.GetByIdAsync(input.fromBankAccountId);
			var to = await _bankAccountRepository.GetByIdAsync(input.toBankAccountId);

			var transferCommand = new TransferCommand(from, to, input.amount);

			await transferCommand.ExecuteAsync();

			await _bankAccountRepository.UpdateAsync(from);
			await _bankAccountRepository.UpdateAsync(to);
		}
    }

	public record Input(int fromBankAccountId, int toBankAccountId, decimal amount) { }
}
