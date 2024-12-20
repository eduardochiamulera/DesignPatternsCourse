﻿namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public abstract class Segment
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

		public abstract double GetValue();
	}


	public class DistanceSegment : Segment
	{
		public DistanceSegment(Guid rideId, Location from, Location to) : base(rideId, from, to)
		{
		}

		private double GetDistance()
		{
			var earthRadius = 6371;
			double degreesToRadians = Math.PI / 180;
			var deltaLat = (To.Coordenada.Latitude - From.Coordenada.Latitude) * degreesToRadians;
			var deltaLon = (To.Coordenada.Longitude - From.Coordenada.Longitude) * degreesToRadians;
			var a =
				Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
				Math.Cos(From.Coordenada.Latitude * degreesToRadians) *
				Math.Cos(To.Coordenada.Latitude * degreesToRadians) *
				Math.Sin(deltaLon / 2) *
				Math.Sin(deltaLon / 2);
			var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			return Math.Round(earthRadius * c);
		}

		public override double GetValue() => GetDistance();
	}

	public class TimeSegment : Segment
	{
		public TimeSegment(Guid rideId, Location from, Location to) : base(rideId, from, to)
		{
		}

		private double GetDiffInMinutes()
		{
			return (To.Date - From.Date).TotalMinutes;
		}

		public override double GetValue() => GetDiffInMinutes();
	}
}
