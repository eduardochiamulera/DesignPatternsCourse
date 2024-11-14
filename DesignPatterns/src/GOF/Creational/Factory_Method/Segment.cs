namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class Segment
	{
		public Segment(Guid rideId, Location from, Location to)
		{
			From = from;
			To = to;
			RideId = rideId;
		}

		public Location From { get; private set; }
		public Location To { get; private set; }
		public Guid RideId { get; private set; }
	}
}
