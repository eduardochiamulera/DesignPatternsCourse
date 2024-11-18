using DesignPatterns.src.GOF.Creational.Singleton;

namespace Tests.GOF.Creational.Singleton
{
	public class SingletonTests
	{
		[Fact]
		public async Task Deve_Criar_Uma_Conta_De_Usuario()
		{
			var signUp = new SignUp();
			var login = new Login();

			var input = new SignUpRequestDto("John Doe", "john.doe@gmail.com", "123456");

			await signUp.Execute(input);

			var inputLogin = new LoginRequestDto("john.doe@gmail.com", "123456");

			var outputLogin = await login.Execute(inputLogin);

			Assert.True(outputLogin.Success);

		}
	}
}
