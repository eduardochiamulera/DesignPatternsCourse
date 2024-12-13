using DesignPatterns.src.GOF.Behavioral.Command;

namespace Tests.GOF.Behavioral.Command
{
	public class BankAccountTests
	{
		[Fact]
		public void Deve_Fazer_Transferencia_Entre_Duas_Contas() 
		{
			var from = new BankAccount(1);
			var to = new BankAccount(2);

			Assert.Equal(0, from.GetBalance());
			Assert.Equal(0, to.GetBalance());

			from.Debit(100);
			to.Credit(100);

			Assert.Equal(-100, from.GetBalance());
			Assert.Equal(100, to.GetBalance());

		}

		[Fact]
		public async void Deve_Fazer_Transferencia_Entre_Duas_Contas_Usando_Um_Command()
		{
			var from = new BankAccount(1);
			var to = new BankAccount(2);

			Assert.Equal(0, from.GetBalance());
			Assert.Equal(0, to.GetBalance());

			var transferCommand = new TransferCommand(from, to, 100);

			await transferCommand.ExecuteAsync();

			Assert.Equal(-100, from.GetBalance());
			Assert.Equal(100, to.GetBalance());

		}
	}
}
