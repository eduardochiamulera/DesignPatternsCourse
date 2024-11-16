namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class UpdateLocation
	{
		private readonly RideRepository _rideRepository;
		private readonly SegmentRepository _segmentRepository;

		public UpdateLocation(RideRepository rideRepository, SegmentRepository segmentRepository)
		{
			_rideRepository = rideRepository;
			_segmentRepository = segmentRepository;
		}

		public void Execute(UpdateLocationRequest input)
		{
			var ride = _rideRepository.GetById(input.rideId);

			var newLocation = new Location(input.Latitude, input.Longitude, input.Date);

			var segment = new Segment(ride.RideId, ride.LastLocation, newLocation);

			ride.UpdateLocation(newLocation);

			_rideRepository.Save(ride);
			_segmentRepository.Save(segment);
		}
	}

	public record UpdateLocationRequest(Guid rideId, double Latitude, double Longitude, DateTime Date) { }
}
