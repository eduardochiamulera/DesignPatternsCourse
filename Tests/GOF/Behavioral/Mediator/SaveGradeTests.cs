using DesignPatterns.src.GOF.Behavioral.Mediator;

namespace Tests.GOF.Behavioral.Mediator
{
	public class SaveGradeTests
	{
		[Fact]
		public async Task Deve_Salvar_Nota_Aluno_E_Calcular_Media()
		{
			long studentId = Math.Abs(Random.Shared.Next() * 1000000);
			var averageRepository = new AverageRepositoryDatabase();
			var gradeRepository = new GradeRepositoryDatabase();
			var calculateAverage = new CalculateAverage(gradeRepository, averageRepository);
			var saveGrade = new SaveGrade(gradeRepository, calculateAverage);
			var inputP1 = new Input(studentId, "P1", 10);
			await saveGrade.ExecuteAsync(inputP1);
			var inputP2 = new Input(studentId, "P2", 9);
			await saveGrade.ExecuteAsync(inputP2);
			var inputP3 = new Input(studentId, "P3", 8);
			
			await saveGrade.ExecuteAsync(inputP3);

			var getAverage = new GetAverage(averageRepository);
			var output = await getAverage.ExecuteAsync(studentId);

			Assert.Equal(9d, output.average);
		}

		[Fact]
		public async Task Deve_Salvar_Nota_Aluno_E_Calcular_Media_Usando_Mediator()
		{
			long studentId = Math.Abs(Random.Shared.Next() * 1000000);
			var averageRepository = new AverageRepositoryDatabase();
			var gradeRepository = new GradeRepositoryDatabase();
			var calculateAverage = new CalculateAverage(gradeRepository, averageRepository);
			var mediator = new DesignPatterns.src.GOF.Behavioral.Mediator.Mediator();
			mediator.Register("gradeSaved", async (data) =>
			{
				Console.WriteLine(data);
				await calculateAverage.ExecuteAsync((long)data);
			});
			var saveGrade = new SaveGradeMediator(gradeRepository, mediator);
			var inputP1 = new Input(studentId, "P1", 10);
			await saveGrade.ExecuteAsync(inputP1);
			var inputP2 = new Input(studentId, "P2", 9);
			await saveGrade.ExecuteAsync(inputP2);
			var inputP3 = new Input(studentId, "P3", 8);

			await saveGrade.ExecuteAsync(inputP3);

			var getAverage = new GetAverage(averageRepository);
			var output = await getAverage.ExecuteAsync(studentId);

			Assert.Equal(9d, output.average);
		}
	}
}
