using DesignPatterns.src.GOF.Creational.Factory_Method;

namespace DesignPatterns.src.GOF.Behavioral.Chain_of_Responsability
{
	public class Segment
	{
        public Segment()
        {
            
        }
        public Segment(double distance, DateTime date)
		{
			Distance = distance;
			Date = date;
			if (!IsValidDistance()) throw new ArgumentException("Invalid distance");
			if (!IsValidDate()) throw new ArgumentException("Invalid date");
		}

		public double Distance { get; set; }
		public DateTime Date { get; set; }

		private bool IsValidDistance()
		{
			return Distance > 0;
		}

		private bool IsValidDate()
		{
			return Date != DateTime.MinValue && Date.Kind != DateTimeKind.Unspecified;
		}

		public bool IsOvernight()
		{
			var hour = Date.Hour;
			return hour >= 22 || hour <= 6;
		}

		public bool IsSunday()
		{
			return Date.DayOfWeek == DayOfWeek.Sunday;
		}
	}
}


