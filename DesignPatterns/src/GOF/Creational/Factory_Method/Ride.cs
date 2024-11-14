namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Ride
	{
		public Ride(decimal latitude, decimal longitude, DateTime date)
		{
			LastLocation = new Location(latitude, longitude, date);
			RideId = Guid.NewGuid();
		}

		public Location LastLocation { get; private set; }
		public Guid RideId { get; private set; }

		public void UpdateLocation(Location location)
		{
			LastLocation = location;
		}
	}
}
