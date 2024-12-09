using System.Text.RegularExpressions;

namespace DesignPatterns.src.GOF.Structural.Bridge
{
	public abstract class Account
	{
		public Account(string name, string email, string document, string password, string passwordType)
		{
			if (!Regex.IsMatch(name, @".+ .+"))
			{
				throw new Exception("Invalid name");
			}

			if (!Regex.IsMatch(email, @".+\@.+\..+"))
			{
				throw new Exception("Invalid email");
			}

			if (document.Length != 11) 
			{
				throw new Exception("Invalid document");
			}

			Name = name;
			Email = email;
			Document = document;
			Password = PasswordFactory.Create(passwordType, password);
		}

		public string Name { get; set; }
		public string Email { get; set; }
		public string Document { get; set; }
		Password Password { get; set; }

		public bool PasswordMatches(string password) 
		{
			return Password.PasswordMatches(password);
		}
	}
}
