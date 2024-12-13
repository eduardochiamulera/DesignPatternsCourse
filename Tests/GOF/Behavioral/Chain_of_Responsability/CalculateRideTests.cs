using DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability;

namespace Tests.GOF.Behavioral.Chain_of_Responsability
{
	public class CalculateRideTests
	{
		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Normal() 
		{
			var segments = new[] {
				new Segment(10, new DateTime(2021, 03, 01, 10, 00, 00, DateTimeKind.Utc))
			};
			
			var fare = CalculateRide.CalculateFare(segments);
			
			Assert.Equal(21, fare);
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Noturno()
		{
			var segments = new[] {
				new Segment(10, new DateTime(2021, 03, 01, 23, 00, 00, DateTimeKind.Utc))
			};

			var fare = CalculateRide.CalculateFare(segments);

			Assert.Equal(39, fare);
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Domingo()
		{
			var segments = new[] {
				new Segment(10, new DateTime(2021, 03, 07, 10, 00, 00, DateTimeKind.Utc))
			};

			var fare = CalculateRide.CalculateFare(segments);

			Assert.Equal(29, fare);
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Horario_Domingo_Noite()
		{
			var segments = new[] {
				new Segment(10, new DateTime(2021, 03, 07, 23, 00, 00, DateTimeKind.Utc))
			};

			var fare = CalculateRide.CalculateFare(segments);

			Assert.Equal(50, fare);
		}

		[Fact]
		public void Deve_Calcular_Valor_Corrida_Com_Tarifa_Minima()
		{
			var segments = new[] {
				new Segment (2, new DateTime(2021, 03, 01, 10, 00, 00, DateTimeKind.Utc))
			};

			var fare = CalculateRide.CalculateFare(segments);

			Assert.Equal(10, fare);
		}

		[Fact]
		public void Nao_Deve_Calcular_Valor_Corrida_Se_Distancia_Invalida()
		{
			var segments = new[] {
				new Segment { Distance = 0 , Date = new DateTime(2021, 03, 01, 10, 00, 00, DateTimeKind.Utc) }
			};

			var ex = Assert.Throws<ArgumentException>(() => CalculateRide.CalculateFare(segments));

			Assert.Equal("Invalid distance", ex.Message);
		}

		[Fact]
		public void Nao_Deve_Calcular_Valor_Corrida_Se_Data_Invalida()
		{
			var segments = new[] {
				new Segment { Distance = 10 , Date = new DateTime(2021, 03, 01, 10, 00, 00 ) }
			};

			var ex = Assert.Throws<ArgumentException>(() => CalculateRide.CalculateFare(segments));

			Assert.Equal("Invalid date", ex.Message);
		}
	}
}
