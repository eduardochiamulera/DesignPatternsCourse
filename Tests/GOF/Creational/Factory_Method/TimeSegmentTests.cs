using DesignPatterns.src.GOF.Creational.Factory_Method;

namespace Tests.GOF.Creational.Factory_Method
{
	public class TimeSegmentTests
	{
		[Fact]
		public void Deve_Criar_Segmento_Por_Tempo()
		{
			Location from = new Location(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));
			Location to = new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00));

			var timeSegment = new TimeSegment(Guid.NewGuid(), from, to);

			Assert.NotNull(timeSegment);
			Assert.True(timeSegment.GetValue() == 120);
		}
	}
}
