namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public class SaveGradeMediator
	{
		private readonly GradeRepository _gradeRepository;
		private readonly Mediator _mediator;
		public SaveGradeMediator(GradeRepository gradeRepository, Mediator mediator)
		{
			this._gradeRepository = gradeRepository;
			_mediator = mediator;
		}

		public async Task ExecuteAsync(Input input)
		{
			var grade = new Grade(input.studentId, input.exam, input.value);

			await _gradeRepository.SaveAsync(grade);

			await _mediator.NotifyAsync("gradeSaved", input.studentId);
		}
	}
}
