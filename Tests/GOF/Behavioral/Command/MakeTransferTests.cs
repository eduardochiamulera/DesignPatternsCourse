using DesignPatterns.src.GOF.Behavioral.Command;

namespace Tests.GOF.Behavioral.Command
{
	public class MakeTransferTests
	{
		[Fact]
		public async Task Deve_Fazer_Transferencia_Bancaria()
		{
			var bankAccountRepository = new BankAccountRepositoryMemory();

			await bankAccountRepository.SaveAsync(new BankAccount(1));
			await bankAccountRepository.SaveAsync(new BankAccount(2));

			var makeTransfer = new MakeTransfer(bankAccountRepository);

			var input = new Input(1, 2, 100);

			await makeTransfer.ExecuteAsync(input);

			var getBalance = new GetBalance(bankAccountRepository);

			var outputA = await getBalance.ExecuteAsync(1);
			var outputB = await getBalance.ExecuteAsync(2);

			Assert.Equal(-100, outputA.Balance);
			Assert.Equal(100, outputB.Balance);
		}
	}
}
