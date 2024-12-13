using Dapper;
using DesignPatterns.src.GOF.Structural.Decorator;
using Microsoft.Data.SqlClient;

namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public interface GradeRepository
	{
		Task SaveAsync(Grade grade);
		Task<IEnumerable<Grade>> ListByStudentIdAsync(long studentId);
	}

	public class GradeRepositoryDatabase : GradeRepository
	{
		public async Task<IEnumerable<Grade>> ListByStudentIdAsync(long studentId)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				return await connection.QueryAsync<Grade>(@$"select [studentId],[exam],[value] from [mediator].[grade]");
			}
		}

		public async Task SaveAsync(Grade grade)
		{
			await using (var connection = new SqlConnection("Server=LENOVO-PC;Database=DeisgnPatterns;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"))
			{
				var result = await connection.ExecuteAsync(@$"insert into [mediator].[grade] (studentId, exam, value) 
																values (@StudentId, @Exam, @Value)", new
				{
					grade.StudentId,
					grade.Exam,
					grade.Value
				});
			}
		}
	}
}
