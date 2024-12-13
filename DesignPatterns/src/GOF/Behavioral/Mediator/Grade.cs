namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public class Grade
	{
		public Grade(long studentId, string exam, double value)
		{
			StudentId = studentId;
			Exam = exam;
			Value = value;
		}

		public long StudentId { get; set; }
		public string Exam { get; set; }
		public double Value { get; set; }
	}
}
