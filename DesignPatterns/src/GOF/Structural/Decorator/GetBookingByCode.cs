namespace DesignPatterns.src.GOF.Structural.Decorator
{

	public class GetBookingByCode
	{
		private readonly BookingRepository _bookingRepository;
		private readonly RoomRepository _roomRepository;

		public GetBookingByCode(BookingRepository bookingRepository, RoomRepository roomRepository)
		{
			_bookingRepository = bookingRepository;
			_roomRepository = roomRepository;
		}

		public async Task<OutputBooking> ExecuteAsync(InputCode input)
		{
			var booking = await _bookingRepository.GetBookingByCodeAsync(input.Code);

			var room = await _roomRepository.GetByIdAsync(booking.RoomId);

			return new(booking.Code, booking.Duration, booking.Price, room.Category);
		}
	}

	public record InputCode(string Code);
	public record OutputBooking(string Code, int Duration, decimal Price, string Category);
}
