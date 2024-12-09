using System.Text.RegularExpressions;

namespace DesignPatterns.src.GOF.Structural.Bridge
{
	public class Driver : Account
	{
		public Driver(string name, string email, string document, string carPlate, string password, string passwordType = "plaintext") : base(name, email, document, password, passwordType)
		{
			if(!Regex.IsMatch(carPlate, "[A-Z]{3}[0-9]{4}"))
			{
				throw new Exception("Invalid carplate");
			}
			CarPlate = carPlate;
		}

		public string CarPlate { get; set; }
	}
}
