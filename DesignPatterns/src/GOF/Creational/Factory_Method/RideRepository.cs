namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public interface RideRepository 
	{
		void Save(Ride ride);
		Ride GetById(Guid rideId);
		void Update(Ride ride);
	}

	public class RideRepositoryMemory : RideRepository
	{

		private List<Ride> _rides;

		public IReadOnlyCollection<Ride> Rides { get { return _rides; } }

		public RideRepositoryMemory()
		{
			_rides = [];
		}

		public Ride GetById(Guid rideId)
		{
			var ride = _rides.Where( x => x.RideId == rideId ).FirstOrDefault();

			if (ride == null)
				throw new KeyNotFoundException("Ride not found.");

			return ride;
		}

		public void Save(Ride ride)
		{
			_rides.Add(ride);
		}

		public void Update(Ride ride)
		{
			var obj = _rides.FindIndex(x => x.RideId == ride.RideId);

			if(obj == -1)
			{
				throw new KeyNotFoundException("Ride not found.");
			}

			_rides[obj] = ride;
		}
	}
}
