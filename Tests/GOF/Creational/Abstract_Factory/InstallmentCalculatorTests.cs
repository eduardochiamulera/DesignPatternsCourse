using DesignPatterns.src.GOF.Creational.Abstract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tests.GOF.Creational.Abstract_Factory
{
	public class InstallmentCalculatorTests
	{
		private readonly ITestOutputHelper _outputHelper;

		public InstallmentCalculatorTests(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public void Deve_Calcular_As_Parcelas_Utilizando_SAC()
		{
			var installmentCalculator = new SACInstallmentCalculator();

			var loan = MortgageLoan.Create(100000, 10000, 240);

			var installments = installmentCalculator.Calculate(loan);

			Assert.True(installments.Count() == 240);
			Assert.True(installments.First()?.Number == 1);
			Assert.True(installments.First()?.Amount == 1250m);
			Assert.True(installments.First()?.Amortization == 416.67m);
			Assert.True(installments.First()?.Interest == 833.33m);
			Assert.True(installments.First()?.Balance == 99583.33m);

			Assert.True(installments.Last()?.Number == 240);
			Assert.True(installments.Last()?.Amount == 420.14m);
			Assert.True(installments.Last()?.Amortization == 416.67m);
			Assert.True(installments.Last()?.Interest == 3.47m);
			Assert.True(installments.Last()?.Balance == 0m);

			_outputHelper.WriteLine(JsonSerializer.Serialize(installments.First()));
		}


		[Fact]
		public void Deve_Calcular_As_Parcelas_Utilizando_Price()
		{
			var installmentCalculator = new PriceInstallmentCalculator();

			var loan = MortgageLoan.Create(100000, 10000, 240);

			var installments = installmentCalculator.Calculate(loan);

			Assert.True(installments.Count() == 240);

			Assert.True(installments.First()?.Number == 1);
			Assert.True(installments.First()?.Amount == 965.02m);
			Assert.True(installments.First()?.Amortization == 131.69m);
			Assert.True(installments.First()?.Interest == 833.33m);
			Assert.True(installments.First()?.Balance == 99868.31m);
			Assert.True(installments.Last()?.Number == 240);
			Assert.True(installments.First()?.Amount == 965.02m);
			Assert.True(installments.Last()?.Amortization == 957.03m);
			Assert.True(installments.Last()?.Interest == 7.99m);
			Assert.True(installments.Last()?.Balance == 0m);
			
			_outputHelper.WriteLine(JsonSerializer.Serialize(installments.First()));
		}
	}
}
