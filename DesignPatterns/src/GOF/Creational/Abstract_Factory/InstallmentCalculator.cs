namespace DesignPatterns.src.GOF.Creational.Abstract_Factory
{
	public interface InstallmentCalculator
	{
		IEnumerable<Installment> Calculate(Loan loan);
	}

	public class SACInstallmentCalculator : InstallmentCalculator
	{
		public IEnumerable<Installment> Calculate(Loan loan)
		{
			var installments = new List<Installment>();

			decimal balance = loan.Amount;

			decimal rate = loan.Rate / 100m / 12;

			int installmentNumber = 1;

			decimal amortization = Math.Round(balance / loan.Installments, 2, MidpointRounding.ToEven);

			while (balance > 0.10m)
			{
				decimal interest = Math.Round(balance * rate, 2, MidpointRounding.ToEven); //juros
				decimal updatedBalance = Math.Round(balance + interest, 2, MidpointRounding.ToEven); //aumenta o saldo para considerar o juros
				decimal amount = Math.Round(interest + amortization, 2, MidpointRounding.ToEven); //valor da parcela (juros + amortização) 
				balance = Math.Round(updatedBalance - amount, 2, MidpointRounding.ToEven); //novo balanco (balanco - valor parcela)
				if (balance < 0.10m)
				{
					balance = 0;
				}
				installments.Add(new Installment(loan.LoanId, installmentNumber, amount, amortization, interest, balance));
				installmentNumber++;
			}

			return installments;
		}
	}

	public class PriceInstallmentCalculator : InstallmentCalculator
	{
		public IEnumerable<Installment> Calculate(Loan loan)
		{
			var installments = new List<Installment>();

			decimal balance = loan.Amount;

			decimal rate = loan.Rate / 100m / 12;

			int installmentNumber = 1;

			var formula = (decimal)Math.Pow((1 + (double)rate), (double)loan.Installments);

			decimal amount = Math.Round(balance * ((formula * rate) / (formula - 1)), 2, MidpointRounding.ToEven);

			while (balance > 2m)
			{
				decimal interest = Math.Round(balance * rate, 2); //juros
				decimal amortization = Math.Round(amount - interest, 2, MidpointRounding.ToEven);
				balance = balance - amortization;
				
				if (balance < 2m)
				{
					balance = 0;
				}

				installments.Add(new Installment(loan.LoanId, installmentNumber, amount, amortization, interest, balance));
				installmentNumber++;
			}

			return installments;
		}
	}
}
