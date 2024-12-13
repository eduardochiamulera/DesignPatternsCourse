using Dapper;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public interface AverageRepository
	{
		Task SaveAsync(Average average);
		Task<Average> GetByStudentIdAsync(long studentId);
	}

	public class AverageRepositoryDatabase : AverageRepository
	{
		public async Task<Average> GetByStudentIdAsync(long studentId)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.QueryAsync<Average>(@$"select [studentId],[value] from [mediator].[average] where [studentId] = @studentId", new { studentId });

				return result.SingleOrDefault();
			}
		}

		public async Task SaveAsync(Average average)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				await connection.ExecuteAsync(@$"delete from [mediator].[average] where studentId = @StudentId", new { average.StudentId });
				await connection.ExecuteAsync(@$"insert into [mediator].[average] (studentId, value) values (@StudentId, @Value)", new
				{
					average.StudentId,
					average.Value
				});
			}
		}
	}
}
