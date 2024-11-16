namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Ride
	{
		public Ride(double latitude, double longitude, DateTime date)
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

		public decimal CalculateFare(IEnumerable<Segment> segments)
		{
			double total = 0;

			foreach (var segment in segments) {
				total += segment.GetDistance();
			}

			return (decimal)total * 4;
		}

	}
}
