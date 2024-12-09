namespace DesignPatterns.src.GOF.Creational.Prototype
{
	public class Field : Prototype
	{
		public Field(Guid id, string type, string title)
		{
			Id = id;
			Type = type;
			Title = title;
		}

		public Guid Id { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }

		public static Field Create(string type, string title)
		{
			return new Field(Guid.NewGuid(), type, title);
		}

		public Prototype Clone()
		{
			return new Field(Id, Type, Title);
		}
	}
}
