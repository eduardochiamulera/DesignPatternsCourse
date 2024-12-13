namespace DesignPatterns.src.GOF.Behavioral.Mediator
{

	public class CalculateAverage
	{
		public readonly GradeRepository _gradeRepository;
		public readonly AverageRepository _averageRepository;

		public CalculateAverage(GradeRepository gradeRepository, AverageRepository averageRepository)
		{
			_gradeRepository = gradeRepository;
			_averageRepository = averageRepository;
		}

		public async Task ExecuteAsync(long studentId)
		{
			var grades = await _gradeRepository.ListByStudentIdAsync(studentId);

			var total = 0d;

			foreach (var grade in grades) 
			{
				total += grade.Value;
			}

			var value = total / grades.Count();

			var average = new Average(studentId, value);

			await _averageRepository.SaveAsync(average);
		}
	}
}
