namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Coordenada
	{
		private readonly decimal _latitude;
		private readonly decimal _longitude;

		public Coordenada(decimal latitude, decimal longitude)
		{
			if(latitude < -90 || latitude > 90) throw new ArgumentOutOfRangeException(nameof(latitude));
			if (_longitude < -180 || _longitude > 180) throw new ArgumentOutOfRangeException(nameof(latitude));
			_latitude = latitude;
			_longitude = longitude;
		}
	}
}
