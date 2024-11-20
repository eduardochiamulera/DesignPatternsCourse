namespace DesignPatterns.src.GOF.Creational.Prototype
{
	public interface FormRepository
	{
		Task<Form> GetById(Guid id);
		Task Save(Form form);
	}
}
