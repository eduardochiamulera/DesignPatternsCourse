using DesignPatterns.src.GOF.Creational.Prototype;
using System.Text.Json;
using Xunit.Abstractions;

namespace Tests.GOF.Creational.Prototype
{
	public class CopyFormTests
	{
		private readonly ITestOutputHelper _outputHelper;

		public CopyFormTests(ITestOutputHelper outputHelper)
		{
			_outputHelper = outputHelper;
		}

		[Fact]
		public async Task Deve_Copiar_Um_Formulario()
		{
			var formRepository = new FormRepositoryMemory();
			
			var id = Guid.NewGuid();

			var form = new Form(id, "Marketing", "Leads v1");
			form.AddField("text", "name");
			form.AddField("text", "email");

			await formRepository.Save(form);

			var copyForm = new CopyForm(formRepository);
			
			var newId = Guid.NewGuid();
			var input = new Input(id, newId, "Marketing", "Leads v2");
			await copyForm.Execute(input);

			_outputHelper.WriteLine(JsonSerializer.Serialize(formRepository.Forms));

			var newForm = await formRepository.GetById(newId);

			Assert.NotNull(newForm);
			Assert.True(newForm.Category == "Marketing");
			Assert.True(newForm.Description == "Leads v2");
			Assert.True(newForm.Fields[0]?.Title == "name");
			Assert.True(newForm.Fields[0]?.Type == "text");
		}

	}
}
