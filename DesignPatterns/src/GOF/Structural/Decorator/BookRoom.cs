namespace DesignPatterns.src.GOF.Structural.Decorator
{

	public class BookRoom : UseCase<Input, Output>
	{
		private readonly RoomRepository _roomRepository;
		private readonly BookingRepository _bookingRoomRepository;

		public BookRoom(RoomRepository roomRepository, BookingRepository bookingRoomRepository)
		{
			_roomRepository = roomRepository;
			_bookingRoomRepository = bookingRoomRepository;
		}

		public async Task<Output> ExecuteAsync(Input input)
		{
			var inputTyped = input;
			var availableRoom = (await _roomRepository.GetAvailableRoomByPeriodAndCategoryAsync(inputTyped.CheckinDate, inputTyped.CheckoutDate, inputTyped.Category)).FirstOrDefault();

			if (availableRoom == null)
			{
				throw new Exception("Room is not available");
			}

			var booking = Booking.Create(availableRoom, inputTyped.Email, inputTyped.CheckinDate, inputTyped.CheckoutDate);

			await _bookingRoomRepository.SaveAsync(booking);

			return new Output(booking.Code);
		}
	}

	public record Input(string Email, DateTime CheckinDate, DateTime CheckoutDate, string Category);
	public record Output(string Code);
}
