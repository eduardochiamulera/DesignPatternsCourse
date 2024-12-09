namespace DesignPatterns.src.GOF.Creational.Prototype
{

	public class CopyForm
	{
		private readonly FormRepository _formRepository;
		public CopyForm(FormRepository formRepository)
		{
			_formRepository = formRepository;
		}

		public async Task Execute(Input input)
		{
			var form = await _formRepository.GetById(input.fromFormId);
			
			var newForm = (Form)form.Clone();

			newForm.Id = input.newFormId;
			newForm.Description = input.newDescription;
			newForm.Category = input.newCategory;

			await _formRepository.Save(newForm);
		}
    }

	public record Input(Guid fromFormId, Guid newFormId, string newCategory, string newDescription);
}
