namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public class Average
	{
		public Average(long studentId, double value)
		{
			StudentId = studentId;
			Value = value;
		}

		public long StudentId { get; set; }
		public double Value { get; set; }
	}
}
