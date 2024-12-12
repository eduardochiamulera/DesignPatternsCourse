namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public class LogDecorator<TInput, TOutput> : UseCase<TInput, TOutput>
	{
		private readonly UseCase<TInput, TOutput> _useCase;

		public LogDecorator(UseCase<TInput, TOutput> useCase)
		{
			_useCase = useCase;
		}

		public Task<TOutput> ExecuteAsync(TInput input)
		{
			Console.WriteLine(input);
			return _useCase.ExecuteAsync(input);
		}
	}
}
