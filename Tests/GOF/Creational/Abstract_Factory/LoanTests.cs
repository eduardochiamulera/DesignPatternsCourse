using DesignPatterns.src.GOF.Creational.Abstract_Factory;

namespace Tests.GOF.Creational.Abstract_Factory
{
	public class LoanTests
    {
        [Fact]
        public void Deve_Criar_Um_Financiamento_Imobiliario()
        {
            decimal amount = 100000;
            decimal income = 10000;
            decimal installments = 240;

			var loan = MortgageLoan.Create(amount, income, installments);

            Assert.True(loan.LoanId != Guid.Empty);
			Assert.Equal(loan.Amount, amount);
            Assert.Equal(loan.Income, income);
            Assert.Equal(loan.Installments, installments);
        }

		[Fact]
		public void Nao_Deve_Criar_Um_Financiamento_Imobiliario_Com_Prazo_Superior_A_420_Meses()
		{
			decimal amount = 100000;
			decimal income = 10000;
			decimal installments = 540;

            var exception = Assert.Throws<Exception>(() => MortgageLoan.Create(amount, income, installments));

			Assert.Equal("The maximum number of installments for mortgage loan is 420.", exception.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Um_Financiamento_Imobiliario_Caso_Parcela_Ocupe_Valor_Superior_25_Porcento_Renda_Mensal()
		{
			decimal amount = 200000;
			decimal income = 1000;
			decimal installments = 420;

			var exception = Assert.Throws<Exception>(() => MortgageLoan.Create(amount, income, installments));

			Assert.Equal("The installment amount could not exceed 25% of monthly income.", exception.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Um_Financiamento_Veicular_Com_Prazo_Superior_A_60_Meses()
		{
			decimal amount = 100000;
			decimal income = 10000;
			decimal installments = 72;

			var exception = Assert.Throws<Exception>(() => CarLoan.Create(amount, income, installments));

			Assert.Equal("The maximum number of installments for car loan is 60.", exception.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Um_Financiamento_Veicular_Caso_Parcela_Ocupe_Valor_Superior_30_Porcento_Renda_Mensal()
		{
			decimal amount = 200000;
			decimal income = 1000;
			decimal installments = 60;

			var exception = Assert.Throws<Exception>(() => CarLoan.Create(amount, income, installments));

			Assert.Equal("The installment amount could not exceed 30% of monthly income.", exception.Message);
		}
	}
}