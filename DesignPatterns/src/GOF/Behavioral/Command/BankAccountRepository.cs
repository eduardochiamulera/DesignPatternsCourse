using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatterns.src.GOF.Behavioral.Command
{
	public interface BankAccountRepository
	{
		Task SaveAsync(BankAccount bankAccount);
		Task UpdateAsync(BankAccount bankAccount);
		Task<BankAccount> GetByIdAsync(int number);
	}

	public class BankAccountRepositoryMemory : BankAccountRepository
	{
		public List<BankAccount> BankAccounts { get; set; }

        public BankAccountRepositoryMemory()
        {
            BankAccounts = new List<BankAccount>();
        }

        public Task<BankAccount> GetByIdAsync(int number)
		{
			var bankAccount = BankAccounts.Find(x => x.Id == number);

			if (bankAccount == null)
			{
				throw new Exception("Not found");
			}

			return Task.FromResult(bankAccount);
		}

		public Task SaveAsync(BankAccount bankAccount)
		{
			BankAccounts.Add(bankAccount);

			return Task.CompletedTask;
		}

		public Task UpdateAsync(BankAccount bankAccount)
		{
			var index = BankAccounts.FindIndex(x => x.Id == bankAccount.Id);

			BankAccounts[index] = bankAccount;

			return Task.CompletedTask;
		}
	}
}
