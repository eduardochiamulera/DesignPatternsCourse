﻿namespace DesignPatterns.src.GOF.Creational.Prototype
{
	public class Form
	{
		public List<Field> Fields { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public Guid Id { get; set; }

        public Form(Guid formId, string category, string description)
        {
			Fields = new List<Field>();
			Id = formId;
			Category = category;
			Description = description;
        }

		public void AddField(string type, string title)
		{
			Fields.Add(Field.Create(type, title));
		}
    }
}