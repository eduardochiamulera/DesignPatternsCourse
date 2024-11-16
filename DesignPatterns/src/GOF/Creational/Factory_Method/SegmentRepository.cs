namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public interface SegmentRepository
	{
		void Save(Segment ride);

		IEnumerable<Segment> GetByRideId(Guid rideId);
	}

	public class SegmentRepositoryMemory : SegmentRepository
	{
		private List<Segment> _segments;

		public IReadOnlyCollection<Segment> Segments { get { return _segments; } }

		public SegmentRepositoryMemory()
		{
			_segments = [];
		}

		public void Save(Segment ride)
		{
			_segments.Add(ride);
		}

		public IEnumerable<Segment> GetByRideId(Guid rideId)
		{
			return _segments.Where(x => x.RideId == rideId);
		}
	}
}
