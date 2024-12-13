namespace DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability
{
	public interface FareCalculator
	{
		FareCalculator? _next { get; }
		double Calculate(Segment segment);
	}

	public class NormalFareCalculator : FareCalculator
	{
		private const double FARE = 2.1;

		public NormalFareCalculator(FareCalculator? next = null)
        {
            _next = next;
        }


		public FareCalculator? _next {get;}

		public double Calculate(Segment segment)
		{
			if (!segment.IsOvernight() && !segment.IsSunday())
			{
				return segment.Distance * FARE;
			}

			if (_next == null)
			{
				throw new Exception();
			}
			
			return _next.Calculate(segment);
		}
	}

	public class OvernightFareCalculator : FareCalculator
	{
		private const double FARE = 3.9;

		public OvernightFareCalculator(FareCalculator? next = null)
		{
			_next = next;
		}


		public FareCalculator? _next { get; }

		public double Calculate(Segment segment)
		{
			if (segment.IsOvernight() && !segment.IsSunday())
			{
				return segment.Distance * FARE;
			}

			if (_next == null)
			{
				throw new Exception();
			}

			return _next.Calculate(segment);
		}
	}

	public class SundayFareCalculator : FareCalculator
	{
		private const double FARE = 2.9;

		public SundayFareCalculator(FareCalculator? next = null)
		{
			_next = next;
		}


		public FareCalculator? _next { get; }

		public double Calculate(Segment segment)
		{
			if (!segment.IsOvernight() && segment.IsSunday())
			{
				return segment.Distance * FARE;
			}

			if (_next == null)
			{
				throw new Exception();
			}

			return _next.Calculate(segment);
		}
	}

	public class OvernightSundayFareCalculator : FareCalculator
	{
		private const double FARE = 5;

		public OvernightSundayFareCalculator(FareCalculator? next = null)
		{
			_next = next;
		}


		public FareCalculator? _next { get; }

		public double Calculate(Segment segment)
		{
			if (segment.IsOvernight() && segment.IsSunday())
			{
				return segment.Distance * FARE;
			}

			if (_next == null)
			{
				throw new Exception();
			}

			return _next.Calculate(segment);
		}
	}
}
