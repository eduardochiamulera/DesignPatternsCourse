using DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability;

namespace Tests.GOF.Behavioral.Chain_of_Responsability
{
	public class RideTests
	{
		private readonly Ride _ride;
        public RideTests()
        {
			var overnightSundayFareCalculator = new OvernightSundayFareCalculator();
			var sundayFareCalculator = new SundayFareCalculator(overnightSundayFareCalculator);
			var overnightFareCalculator = new OvernightFareCalculator(sundayFareCalculator);
			var normalFareCalculator = new NormalFareCalculator(overnightFareCalculator);
			_ride = new Ride(normalFareCalculator);

		}

        [Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Normal() 
		{
			_ride.AddSegment(10, new DateTime(2021, 03, 01, 10, 00, 00, DateTimeKind.Utc));

			_ride.CalculateFare();
			
			Assert.Equal(21, _ride.GetFare());
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Noturno()
		{
			_ride.AddSegment(10, new DateTime(2021, 03, 01, 23, 00, 00, DateTimeKind.Utc));

			_ride.CalculateFare();

			Assert.Equal(39, _ride.GetFare());
		}

		[Fact]
		public void Nao_Deve_Calcular_Valor_Corrida_Se_Distancia_Invalida()
		{
			var ex = Assert.Throws<ArgumentException>(() => _ride.AddSegment(-10, new DateTime(2021, 03, 01, 10, 00, 00, DateTimeKind.Utc)));

			Assert.Equal("Invalid distance", ex.Message);
		}

		[Fact]
		public void Nao_Deve_Calcular_Valor_Corrida_Se_Data_Invalida()
		{
			var ex = Assert.Throws<ArgumentException>(() => _ride.AddSegment(-10, new DateTime(2021, 03, 01, 10, 00, 00)));

			Assert.Equal("Invalid distance", ex.Message);
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Domingo()
		{
			_ride.AddSegment(10, new DateTime(2021, 03, 07, 10, 00, 00, DateTimeKind.Utc));

			_ride.CalculateFare();

			Assert.Equal(29, _ride.GetFare());
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Domingo_Noite()
		{
			_ride.AddSegment(10, new DateTime(2021, 03, 07, 23, 00, 00, DateTimeKind.Utc));

			_ride.CalculateFare();

			Assert.Equal(50, _ride.GetFare());
		}
	}
}
