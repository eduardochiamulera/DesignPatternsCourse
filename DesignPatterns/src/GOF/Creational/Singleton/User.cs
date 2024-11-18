namespace DesignPatterns.src.GOF.Creational.Singleton
{
	public class User
	{
		public User(Guid userId, string name, string email, string password)
		{
			UserId = userId;
			Name = name;
			Email = email;
			Password = password;
		}

		public Guid UserId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public static User Create(string Name,  string Email, string Password)
		{
			return new User(Guid.NewGuid(), Name, Email, Password);
		}

		public bool PasswordMatches(string password) { 
			return Password.Equals(Password);
		}
	}
}
