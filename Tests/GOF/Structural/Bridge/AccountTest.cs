using DesignPatterns.src.GOF.Structural.Bridge;

namespace Tests.GOF.Structural.Bridge
{
	public class AccountTest
	{
		[Fact]
		public void Deve_Criar_Uma_Conta_De_Usuario_Tipo_Passageiro()
		{
			var account = new Passenger("John Doe", "john.doe@gmail.com", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456");

			Assert.Equal(account.Name, "John Doe");
			Assert.Equal(account.Email, "john.doe@gmail.com");
		}

		[Fact]
		public void Nao_Deve_Criar_Uma_Conta_De_Usuario_Tipo_Passageiro_Com_Nome_Invalido()
		{
			var ex = Assert.Throws<Exception>(() => new Passenger("John", "john.doe@gmail.com", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456"));

			Assert.Equal("Invalid name", ex.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Uma_Conta_De_Usuario_Tipo_Passageiro_Com_Email_Invalido()
		{
			var ex =  Assert.Throws<Exception>(() => new Passenger("John Doe", "john.doe@gmail", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456"));
			
			Assert.Equal("Invalid email", ex.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Uma_Conta_De_Usuario_Tipo_Passageiro_Com_Documento_Invalido()
		{
			var ex = Assert.Throws<Exception>(() => new Passenger("John Doe", "john.doe@gmail.com", "1111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456"));

			Assert.Equal("Invalid document", ex.Message);
		}

		[Fact]
		public void Nao_Deve_Criar_Uma_Conta_De_Usuario_Tipo_Passageiro_Com_cvv_Invalido()
		{
			var ex = Assert.Throws<Exception>(() => new Passenger("John Doe", "john.doe@gmail.com", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "12", "123456"));

			Assert.Equal("Invalid cvv", ex.Message);
		}

		[Fact]
		public void Deve_Criar_Uma_Conta_De_Usuario_Tipo_Motorista()
		{
			var account = new Driver("John Doe", "john.doe@gmail.com", "11111111111", "AAA9999", "123456");

			Assert.True(account.Name == "John Doe");
			Assert.True(account.Email == "john.doe@gmail.com");
		}

		[Fact]
		public void Deve_Criar_Uma_Conta_De_Usuario_Tipo_Motorista_Com_Placa_Invalida()
		{
			var ex = Assert.Throws<Exception>(() => new Driver("John Doe", "john.doe@gmail.com", "11111111111", "AAA999", "123456"));

			Assert.Equal("Invalid carplate", ex.Message);
		}

		[Fact]
		public void Deve_Validar_Senha_Armazenada_Texto_Plano_Conta_Tipo_Passageiro()
		{
			var account = new Passenger("John Doe", "john.doe@gmail.com", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456");

			Assert.True(account.PasswordMatches("123456"));
		}

		[Fact]
		public void Deve_Validar_Senha_Armazenada_SHA1_Conta_Tipo_Passageiro()
		{
			var account = new Passenger("John Doe", "john.doe@gmail.com", "11111111111", "JOHN DOE", "1111 1111 1111 1111", "08/28", "123", "123456");

			Assert.True(account.PasswordMatches("123456"));
		}
	}
}
