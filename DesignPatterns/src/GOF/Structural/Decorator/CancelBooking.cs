namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public class CancelBooking
	{
		private readonly BookingRepository _bookingRepository;

		public CancelBooking(BookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		public async Task ExecuteAsync(InputCancel input)
		{
			var booking = await _bookingRepository.GetBookingByCodeAsync(input.Code);
			booking.Cancel();
			await _bookingRepository.UpdateAsync(booking);
		}
	}

	public record InputCancel(string Code);
}
