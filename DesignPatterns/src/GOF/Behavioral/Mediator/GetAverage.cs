namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public class GetAverage
	{
		public readonly AverageRepository _averageRepository;

		public GetAverage(AverageRepository averageRepository)
		{
			_averageRepository = averageRepository;
		}
		public async Task<OutputAverage> ExecuteAsync(long studentId)
		{
			var grades = await _averageRepository.GetByStudentIdAsync(studentId);

			return new OutputAverage(grades.Value);
		}

	}

	public record OutputAverage(double average) { }
}
