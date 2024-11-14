namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Location
	{
		public Coordenada Coordenada { get; private set; }
		public readonly DateTime Date;

		public Location(decimal latitude, decimal longitude, DateTime date)
		{
			Date = date;
			Coordenada = new Coordenada(latitude, longitude);
		}
	}
}
