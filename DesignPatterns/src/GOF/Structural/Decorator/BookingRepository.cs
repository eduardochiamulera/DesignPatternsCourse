using Dapper;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public interface BookingRepository
	{
		Task SaveAsync(Booking booking);
		Task<Booking> GetBookingByCodeAsync(string code);
		Task UpdateAsync(Booking booking);
	}

	public class BookingRepositoryDatabase : BookingRepository
	{
		public async Task<Booking> GetBookingByCodeAsync(string code)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.QueryAsync<Booking>(@$"select 
																		[code] as [code]
																		,[room_id] as [roomId]
																		,[checkinDate] as [checkinDate]
																		,[checkoutDate] as [checkoutDate]
																		,[duration] as [duration]
																		,[price] as [price]
																		,[email] as [email]
																		,[status] as [status]
																	from design_patterns.booking where code = @code", new { code });

				return result.SingleOrDefault();
			}
		}

		public async Task SaveAsync(Booking booking)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.ExecuteAsync(@$"insert into design_patterns.booking (code, room_id, email, checkinDate, checkoutDate, duration, price, status) 
																values (@Code, @RoomId, @Email, @CheckinDate, @CheckoutDate, @Duration, @Price, @Status)", new
				{
					booking.Code,
					booking.RoomId,
					booking.Email,
					booking.CheckinDate,
					booking.CheckoutDate,
					booking.Duration,
					booking.Price,
					Status = booking.GetStatus()
				});

			}
		}

		public async Task UpdateAsync(Booking booking)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.ExecuteAsync(@$"update design_patterns.booking set status = @status where code = @code", new { code = booking.Code, status = booking.GetStatus() });

			}
		}
	}
}
