using DesignPatterns.src.GOF.Structural.Decorator;
using Xunit.Abstractions;

namespace Tests.GOF.Structural.Decorator
{
	public class ImportBookRoomTests
	{
		private readonly ITestOutputHelper _outputHelper;

		public ImportBookRoomTests(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task Deve_Importar_Uma_Lista_De_Reservas()
		{
			var roomRepository = new RoomRepositoryDatabase();
			var bookingRepository = new BookingRepositoryDatabase();
			var importBooking = new LogDecorator<InputImport, OutputImport>(new ImportBooking(new LogDecorator<Input, Output>(new BookRoom(roomRepository, bookingRepository))));


			var input = new InputImport(@"email;checkin_date;checkout_date;category;
john.doe1@gmail.com;2021-03-01T10:00:00;2021-03-03T10:00:00;suite;
john.doe2@gmail.com;2021-03-06T10:00:00;2021-03-08T10:00:00;suite;
john.doe3@gmail.com;2021-03-20T10:00:00;2021-03-22T10:00:00;suite;");

			var outputImportBooking = (OutputImport)await importBooking.ExecuteAsync(input);

			var getBookingByCode = new GetBookingByCode(bookingRepository, roomRepository);
			foreach (var item in outputImportBooking.Codes )
			{
				var outputGetBookingByCode = await getBookingByCode.ExecuteAsync(new InputCode(item));
				Assert.Equal(2, outputGetBookingByCode.Duration);
				Assert.Equal(1000, outputGetBookingByCode.Price);
				
				var cancelBooking = new CancelBooking(bookingRepository);
				await cancelBooking.ExecuteAsync(new InputCancel(item));
			}
		}
	}
}
