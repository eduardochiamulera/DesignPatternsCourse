using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Dapper;

namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public interface RoomRepository
	{
		Task<IEnumerable<Room>> GetAvailableRoomByPeriodAndCategoryAsync(DateTime checkingDate, DateTime checkoutDate, string category);
		Task<Room> GetByIdAsync(int id);
	}

	public class RoomRepositoryDatabase : RoomRepository
	{
		public async Task<IEnumerable<Room>> GetAvailableRoomByPeriodAndCategoryAsync(DateTime checkinDate, DateTime checkoutDate, string category)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var sql = @$"select 
																[room_id] as [RoomId]
																,[category] as [Category]
																,[price] as [Price]
																,[status] as [Status]
																from design_patterns.room
																where category = @category
																and status = 'available'
																and room_id not in (select room_id from design_patterns.booking
																	where checkinDate >= @checkinDate and checkoutDate <= @checkoutDate and status = 'confirmed')";

				var result = await connection.QueryAsync<Room>(sql, new { category, checkinDate = checkinDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff"), 
																		checkoutDate = checkoutDate.ToString("yyyy-MM-dd HH:mm:ss.fffffff") });

				return result;
			}
		}

		public async Task<Room> GetByIdAsync(int id)
		{

			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.QueryAsync<Room>(@$"select
																[room_id] as [RoomId]
																,[category] as [Category]
																,[price] as [Price]
																,[status] as [Status]
																from design_patterns.room where room_id = @id", new { id });

				return result.SingleOrDefault();
			}
		}
	}
}
