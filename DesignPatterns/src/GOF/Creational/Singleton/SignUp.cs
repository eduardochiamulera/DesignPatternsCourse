namespace DesignPatterns.src.GOF.Creational.Singleton
{
	public class SignUp
	{
        private readonly UserRepository _userRepository;

		public SignUp()
		{
			_userRepository = UserRepositoryMemory.GetInstance();
		}

		public async Task Execute(SignUpRequestDto input)
        {
            var user = User.Create(input.Name, input.Email, input.Password);
			await _userRepository.SaveAsync(user);
        }
    }

	public record SignUpRequestDto(string Name, string Email, string Password);
}
