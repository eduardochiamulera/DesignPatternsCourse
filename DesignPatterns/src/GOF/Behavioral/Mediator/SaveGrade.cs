namespace DesignPatterns.src.GOF.Behavioral.Mediator
{

	public class SaveGrade
	{
		private readonly GradeRepository gradeRepository;
		private readonly CalculateAverage calculateAverage;
		public SaveGrade(GradeRepository gradeRepository, CalculateAverage calculateAverage)
		{
			this.gradeRepository = gradeRepository;
			this.calculateAverage = calculateAverage;
		}

		public async Task ExecuteAsync(Input input)
		{
			var grade = new Grade(input.studentId, input.exam, input.value);

			await gradeRepository.SaveAsync(grade);

			await calculateAverage.ExecuteAsync(input.studentId);
		}
	}

	public record Input(long studentId, string exam, double value);
}
