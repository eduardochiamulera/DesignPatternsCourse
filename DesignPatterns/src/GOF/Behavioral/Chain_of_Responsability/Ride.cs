namespace DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability
{
	public class Ride
	{
        private readonly FareCalculator _fareCalculator;
		public Ride(FareCalculator fareCalculator)
		{
			Segments = new List<Segment>();
			Fare = 0;
			_fareCalculator = fareCalculator;
		}
		private List<Segment> Segments { get; set; }
		private double Fare { get; set; }

		public void AddSegment(double distance, DateTime date)
		{
			Segments.Add(new Segment(distance, date));
		}

		public void CalculateFare()
		{
			Fare = 0;
			foreach (var segment in Segments)
			{
				Fare += _fareCalculator.Calculate(segment);
			}

			Fare = Fare < 10 ? 10 : Fare;
		}

		public double GetFare() { return Fare; }
	}
}


