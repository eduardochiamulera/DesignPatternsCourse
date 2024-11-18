namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public abstract class Ride
	{
		public Ride(Guid rideId, double latitude, double longitude, DateTime date)
		{
			LastLocation = new Location(latitude, longitude, date);
			RideId = rideId;
		}

		public Location LastLocation { get; private set; }
		public Guid RideId { get; private set; }
		public void UpdateLocation(Location location)
		{
			LastLocation = location;
		}

		public abstract decimal CalculateFare(IEnumerable<Segment> segments);

		public abstract Segment CreateSegment(Location from, Location to);
	}


	public class DistanceRide : Ride
	{
		public DistanceRide(Guid rideId, double latitude, double longitude, DateTime date) : base(rideId, latitude, longitude, date)
		{
		}

		public override decimal CalculateFare(IEnumerable<Segment> segments)
		{
			double total = 0;

			foreach (var segment in segments)
			{
				total += segment.GetValue();
			}

			return (decimal)total * 4;
		}

		public override Segment CreateSegment(Location from, Location to)
		{
			return new DistanceSegment(RideId, from, to);
		}
	
		public static Ride Create(double latitude, double longitude, DateTime date) //static factory method
		{
			var rideId = Guid.NewGuid();
			return new DistanceRide(rideId, latitude, longitude, date);
		}
	}

	public class TimeRide : Ride
	{
		public TimeRide(Guid rideId, double latitude, double longitude, DateTime date) : base(rideId, latitude, longitude, date)
		{
		}

		public override decimal CalculateFare(IEnumerable<Segment> segments)
		{
			double total = 0;

			foreach (var segment in segments)
			{
				total += segment.GetValue();
			}

			return (decimal)total * 1;
		}

		public override Segment CreateSegment(Location from, Location to)
		{
			return new TimeSegment(RideId, from, to);
		}

		public static Ride Create(double latitude, double longitude, DateTime date) //static factory method
		{
			var rideId = Guid.NewGuid();
			return new TimeRide(rideId, latitude, longitude, date);
		}
	}
}
