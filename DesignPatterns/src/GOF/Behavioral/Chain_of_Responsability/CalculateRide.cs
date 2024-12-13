namespace DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability
{
	public static class CalculateRide
	{
		public static double CalculateFare(IEnumerable<Segment> segments)
		{
			double fare = 0;

			foreach (var segment in segments)
			{
				if (!IsValidDistance(segment.Distance)) throw new ArgumentException("Invalid distance");
				if (!IsValidDate(segment.Date)) throw new ArgumentException("Invalid date");

				if (IsOvernight(segment.Date) && !IsSunday(segment.Date))
				{
					fare += segment.Distance * 3.90;
				}
				else if (IsOvernight(segment.Date) && IsSunday(segment.Date))
				{
					fare += segment.Distance * 5;
				}
				else if (!IsOvernight(segment.Date) && IsSunday(segment.Date))
				{
					fare += segment.Distance * 2.9;
				}
				else if (!IsOvernight(segment.Date) && !IsSunday(segment.Date))
				{
					fare += segment.Distance * 2.10;
				}
			}

			return fare < 10 ? 10 : fare;
		}

		private static bool IsValidDistance(double distance)
		{
			return distance > 0;
		}

		private static bool IsValidDate(DateTime date)
		{
			return date != DateTime.MinValue && date.Kind != DateTimeKind.Unspecified;
		}

		private static bool IsOvernight(DateTime date)
		{
			var hour = date.Hour;
			return hour >= 22 || hour <= 6;
		}

		private static bool IsSunday(DateTime date)
		{
			return date.DayOfWeek == DayOfWeek.Sunday;
		}
	}
}


