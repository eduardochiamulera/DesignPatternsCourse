using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public class CalculateFare
	{
		private readonly RideRepository _rideRepository;
		private readonly SegmentRepository _segmentRepository;

		public CalculateFare(RideRepository rideRepository, SegmentRepository segmentRepository)
		{
			_rideRepository = rideRepository;
			_segmentRepository = segmentRepository;
		}

		public FareResponse Execute(Guid rideId)
		{
			var ride = _rideRepository.GetById(rideId);

			var segments = _segmentRepository.GetByRideId(rideId);

			var fare = ride.CalculateFare(segments);

			return new FareResponse(fare);
		}
	}

	public record FareResponse(decimal Fare) { }
}
