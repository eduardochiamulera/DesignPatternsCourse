namespace DesignPatterns.src.GOF.Creational.Prototype
{
	public interface FormRepository
	{
		Task<Form> GetById(Guid id);
		Task Save(Form form);
	}

	public class FormRepositoryMemory : FormRepository
	{
		private List<Form> _forms;
		public IReadOnlyCollection<Form> Forms => _forms;

		public FormRepositoryMemory()
		{
			_forms = new List<Form>();
		}


		public Task<Form> GetById(Guid id)
		{
			var form = _forms.FirstOrDefault(x => x.Id == id);

			if (form == null) 
			{
				throw new KeyNotFoundException("Form not found.");
			}

			return Task.FromResult(form);
		}

		public Task Save(Form form)
		{
			_forms.Add(form);
			return Task.CompletedTask;
		}
	}
}
