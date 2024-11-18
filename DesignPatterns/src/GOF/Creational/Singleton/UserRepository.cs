using System.Collections.ObjectModel;

namespace DesignPatterns.src.GOF.Creational.Singleton
{
	public interface UserRepository
	{
		Task SaveAsync(User user);
		Task<User> FindByEmailAsync(string email);
	}

	public class UserRepositoryMemory : UserRepository
	{
		private List<User> _users;
		static UserRepository Instance;

		private UserRepositoryMemory()
		{
			_users = new List<User>();
		}

		public IReadOnlyCollection<User> Users => _users;

		public Task<User> FindByEmailAsync(string email)
		{
			var user = _users.FirstOrDefault(x => x.Email == email);

			return Task.FromResult(user);
		}

		public Task SaveAsync(User user)
		{
			_users.Add(user);
			return Task.CompletedTask;
		}

		public static UserRepository GetInstance()
		{
			if(Instance == null)
			{
				Instance = new UserRepositoryMemory();
			}

			return Instance;
		}
	}
}
