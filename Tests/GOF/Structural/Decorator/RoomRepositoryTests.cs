using DesignPatterns.src.GOF.Structural.Decorator;

namespace Tests.GOF.Structural.Decorator
{
	public class RoomRepositoryTests
	{
		[Fact]
		public async Task Deve_Obter_Um_Quarto()
		{
			var roomRepository = new RoomRepositoryDatabase();
			var room = await roomRepository.GetByIdAsync(1);

			Assert.Equal("suite", room.Category);
			Assert.Equal(500, room.Price);
		}

		[Fact]
		public async Task Deve_Obter_Um_Quarto_Disponivel_Para_Reserva_Em_Um_Periodo()
		{
			var roomRepository = new RoomRepositoryDatabase();
			var room = (await roomRepository.GetAvailableRoomByPeriodAndCategoryAsync(new DateTime(2021, 03, 01, 10, 00, 00), new DateTime(2021, 03, 05, 10, 00, 00), "suite")).FirstOrDefault();

			Assert.Equal("suite", room.Category);
			Assert.Equal(500, room.Price);
		}

		[Fact]
		public async Task Nao_Deve_Obter_Um_Quarto_Disponivel_Para_Reserva_Em_Um_Periodo()
		{
			var roomRepository = new RoomRepositoryDatabase();
			var rooms = await roomRepository.GetAvailableRoomByPeriodAndCategoryAsync(new DateTime(2021, 03, 01, 10, 00, 00), new DateTime(2021, 03, 05, 10, 00, 00), "suite");

			Assert.Empty(rooms);
		}
	}
}
