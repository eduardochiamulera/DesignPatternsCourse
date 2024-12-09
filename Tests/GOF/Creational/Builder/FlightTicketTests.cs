using DesignPatterns.src.GOF.Creational.Builder;

namespace Tests.GOF.Creational.Builder
{
	public class FlightTicketTests
	{
		[Fact]
		public void Deve_Criar_Uma_Passagem_Aerea()
		{
			var builder = new FlightTicketBuilder()
			.SetFlight("Azul", "9876")
			.SetTrip("FLN", "GRU")
			.SetPassanger("John Doe", "john.doe@gmail.com", "111.111.111-11", "M")
			.SetEmergencyContact("Bob Simpson", "51999999999")
			.SetSeat("8A")
			.SetCheckedBags(2)
			.SetCheckinInformation(true, "1", "4A")
			.SetPriority(5);

			var flightTicket = new FlightTicket(builder);

			Assert.True(flightTicket.PassengerName == "John Doe");
			Assert.True(flightTicket.FlightCode == "9876");
		}
	}
}
