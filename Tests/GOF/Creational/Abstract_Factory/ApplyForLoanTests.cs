using DesignPatterns.src.GOF.Creational.Abstract_Factory;

namespace Tests.GOF.Creational.Abstract_Factory
{
	public class ApplyForLoanTests
	{
		[Fact]
		public void Deve_Solicitar_Um_Financiamento_Imobiliario()
		{
			var repositoryFactory = new RepositoryMemoryFactory();

			var loanFactoryProvider = new LoanFactoryMemoryProvider();

			var applyForLoan = new ApplyForLoan(repositoryFactory, loanFactoryProvider.Create(LoanType.Mortgage));

			var input = new ApplyForLoanRequestDTO(100000, 10000, 240);

			var outputApplyForLoan = applyForLoan.Execute(input);

			var getLoan = new GetLoan(repositoryFactory);

			var outputGetLoan = getLoan.Execute(new GetLoanRequestDTO(outputApplyForLoan.LoanId));

			Assert.NotEmpty(outputGetLoan.Installments);
			Assert.True(outputGetLoan.Installments.Count() == 240);
			Assert.True(outputGetLoan.Amount == 100000);
			Assert.True(outputGetLoan.Income == 10000);
			Assert.True(outputGetLoan.Installments.First()?.Number == 1);
			Assert.True(outputGetLoan.Installments.First()?.Amount == 1250m);
			Assert.True(outputGetLoan.Installments.First()?.Amortization == 416.67m);
			Assert.True(outputGetLoan.Installments.First()?.Interest == 833.33m);
			Assert.True(outputGetLoan.Installments.First()?.Balance == 99583.33m);

			Assert.True(outputGetLoan.Installments.Last()?.Number == 240);
			Assert.True(outputGetLoan.Installments.Last()?.Amount == 420.14m);
			Assert.True(outputGetLoan.Installments.Last()?.Amortization == 416.67m);
			Assert.True(outputGetLoan.Installments.Last()?.Interest == 3.47m);
			Assert.True(outputGetLoan.Installments.Last()?.Balance == 0m);
		}
	}
}
