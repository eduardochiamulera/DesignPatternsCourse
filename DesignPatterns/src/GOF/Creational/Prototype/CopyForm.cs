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
			var newForm = new Form(input.newFormId, input.newCategory, input.newDescription);
			var fields = new List<Field>();
			foreach (var field in form.Fields)
			{
				fields.Add(new Field(field.Id, field.Type, field.Title));
			}
			newForm.Fields = fields;
			await _formRepository.Save(newForm);
		}
    }

	public record Input(Guid fromFormId, Guid newFormId, string newCategory, string newDescription);
}
