namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Coordenada
	{
		public double Latitude { get; private set; }
		public double Longitude { get; private set; }

		public Coordenada(double latitude, double longitude)
		{
			if(latitude < -90 || latitude > 90) throw new ArgumentOutOfRangeException(nameof(latitude));
			if (Longitude < -180 || Longitude > 180) throw new ArgumentOutOfRangeException(nameof(latitude));
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
