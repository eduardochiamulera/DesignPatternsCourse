using DesignPatterns.src.GOF.Creational.Factory_Method;

namespace Tests.GOF.Creational.Factory_Method
{
	public class RideTests
	{
		[Fact]
		public void Deve_Criar_E_Calcular_A_Tarifa_De_Uma_Corrida_Por_Distancia() 
		{ 
			var ride = DistanceRide.Create(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));

			Location from = new Location(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));
			Location to = new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00));

			var segment = new DistanceSegment(ride.RideId, from, to);

			ride.UpdateLocation(new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00)));

			var fare = ride.CalculateFare([segment]);

			Assert.True(fare == 40m);
		}

		[Fact]
		public void Deve_Criar_E_Calcular_A_Tarifa_De_Uma_Corrida_Por_Tempo()
		{
			var ride = TimeRide.Create(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));

			Location from = new Location(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));
			Location to = new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00));

			var segment = new TimeSegment(ride.RideId, from, to);

			ride.UpdateLocation(new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00)));

			var fare = ride.CalculateFare([segment]);

			Assert.True(fare == 120m);
		}
	}
}
