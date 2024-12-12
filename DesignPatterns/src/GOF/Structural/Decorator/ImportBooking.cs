namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public class ImportBooking : UseCase<InputImport, OutputImport>
	{
		private readonly UseCase<Input, Output> _useCase;

		public ImportBooking(UseCase<Input, Output> useCase)
		{
			_useCase = useCase;
		}

		public async Task<OutputImport> ExecuteAsync(InputImport input)
		{
			var lines = input.File.Split("\n");
			
			var listBooks = new List<string>();

			for (int i = 1;i < lines.Length; i++)
			{
				var line = lines[i].Split(";");
				var email = line[0];
				var checkinDate = line[1];
				var checkoutDate = line[2];
				var category = line[3];

				var inputUseCase = new Input(email, DateTime.Parse(checkinDate), DateTime.Parse(checkoutDate), category);

				var outputUseCase = await _useCase.ExecuteAsync(inputUseCase);

				listBooks.Add(outputUseCase.Code);
			}

			return new OutputImport(listBooks);
		}
	}

	public record InputImport(string File);
	public record OutputImport(IEnumerable<string> Codes);
}
