using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

			var input = new Object();

			updateLocation.Execute(input);

			var calculateFare = new CalculateFare(ride, segmentRepository);

			var output = calculateFare.Execute(ride.RideId);

			Assert.Equal(output.Fare, 40m);
		}
	}
}
