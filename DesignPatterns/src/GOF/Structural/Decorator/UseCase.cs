namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public interface UseCase<TInput, TOutput>
	{
		Task<TOutput> ExecuteAsync(TInput input);
	}
}
