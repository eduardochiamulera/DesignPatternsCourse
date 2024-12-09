namespace DesignPatterns.src.GOF.Structural.Bridge
{

	public class Passenger : Account
	{
		public Passenger(string name, string email, string document, string cardHolder, string cardNumber, string expDate, string cvv, string password, string passwordType = "plaintext") : base(name, email, document, password, passwordType)
		{
			if(cvv.Length != 3)
			{
				throw new Exception("Invalid cvv");
			}

			CardHolder = cardHolder;
			CardNumber = cardNumber;
			ExpDate = expDate;
			Cvv = cvv;
		}

		public string CardHolder { get; set; }
		public string CardNumber { get; set; }
		public string ExpDate { get; set; }
		public string Cvv { get; set; }
	}
}
