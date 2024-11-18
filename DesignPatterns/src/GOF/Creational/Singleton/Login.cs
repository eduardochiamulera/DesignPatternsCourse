namespace DesignPatterns.src.GOF.Creational.Singleton
{
	public class Login
	{
		private readonly UserRepository _userRepository;

		public Login()
		{
			_userRepository = UserRepositoryMemory.GetInstance();
		}

		public async Task<LoginResponseDto> Execute(LoginRequestDto input)
		{
			bool success = false;
			var user = await _userRepository.FindByEmailAsync(input.Email);

			success = user != null && user.PasswordMatches(input.Password);

			return new LoginResponseDto(success);
		}
	}

	public record LoginRequestDto(string Email, string Password);
	public record LoginResponseDto(bool Success);
}
