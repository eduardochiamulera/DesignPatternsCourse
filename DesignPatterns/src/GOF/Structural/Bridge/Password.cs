using System.Security.Cryptography;
using System.Text;

namespace DesignPatterns.src.GOF.Structural.Bridge
{
	public interface Password
	{
		string Value { get; }
		bool PasswordMatches(string password);
	}

	public class PasswordPlainText : Password
	{
        public PasswordPlainText(string password)
        {
            Value = password;
        }
		public string Value { get; }

		public bool PasswordMatches(string password)
		{
			return Value == password;
		}
	}

	public class PasswordSHA1 : Password
	{
		public PasswordSHA1(string password)
		{
			Value = GetSha1Hash(password);
		}
		public string Value { get; }

		public bool PasswordMatches(string password)
		{
			return Value == GetSha1Hash(password);
		}

		private string GetSha1Hash(string input)
		{
			using (SHA1 sha1 = SHA1.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);

				byte[] hashBytes = sha1.ComputeHash(inputBytes);

				StringBuilder sb = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					sb.Append(b.ToString("x2"));
				}

				return sb.ToString();
			}
		}
	}
	

	public class PasswordFactory
	{
		public static Password Create(string type, string password)
		{
			if(type == "plaintext") return new PasswordPlainText(password);
			
			if(type == "sha1") return new PasswordSHA1(password);
			
			throw new ArgumentNullException("type");
		}
	}
}
