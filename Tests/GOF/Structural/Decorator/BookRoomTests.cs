using DesignPatterns.src.GOF.Structural.Decorator;

namespace Tests.GOF.Structural.Decorator
{
	public class BookRoomTests
	{
		[Fact]
		public async Task Deve_Reservar_Um_Quarto()
		{
			var roomRepository = new RoomRepositoryDatabase();
			var bookingRepository = new BookingRepositoryDatabase();
			var bookRoom = new BookRoom(roomRepository, bookingRepository);
			
			var input = new Input("john.doe@gmail.com", new DateTime(2021, 03, 01, 10, 00, 00), new DateTime(2021, 03, 05, 10, 00, 00), "suite");

			var outputBookRoom = await bookRoom.ExecuteAsync(input);
			var getBookingByCode = new GetBookingByCode(bookingRepository, roomRepository);
			var outputGetBookingByCode = await getBookingByCode.ExecuteAsync(new InputCode(outputBookRoom.Code));

			Assert.Equal(4, outputGetBookingByCode.Duration);
			Assert.Equal(2000, outputGetBookingByCode.Price);

			var cancelBooking = new CancelBooking(bookingRepository);
			await cancelBooking.ExecuteAsync(new InputCancel(outputBookRoom.Code));
		}
	}
}
