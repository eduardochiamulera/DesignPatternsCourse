using DesignPatterns.src.GOF.Creational.Factory_Method;

namespace Tests.GOF.Creational.Factory_Method
{
	public class UpdateLocationTests
	{
		[Fact]
		public void Deve_Atualizar_Localizacao_Da_Corrida_Por_Distancia()
		{

			var rideRepository = new RideRepositoryMemory();
			var segmentRepository = new SegmentRepositoryMemory();

			var ride = new Ride(-27.584905257808835, -48.545022195325124, new DateTime(2021,03,01,10,00,00));

			rideRepository.Save(ride);

			var updateLocation = new UpdateLocation(rideRepository, segmentRepository);

			var input = new UpdateLocationRequest(ride.RideId, -27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00));

			updateLocation.Execute(input);

			var calculateFare = new CalculateFare(rideRepository, segmentRepository);

			var output = calculateFare.Execute(ride.RideId);

			Assert.Equal(40m, output.Fare);
		}
	}
}
