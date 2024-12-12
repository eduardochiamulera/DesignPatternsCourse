namespace DesignPatterns.src.GOF.Structural.Decorator
{
	public class Booking
	{
		public Booking(string code, int roomId, DateTime checkinDate, DateTime checkoutDate, int duration, decimal price, string email, string status)
		{
			Code = code;
			RoomId = roomId;
			CheckinDate = checkinDate;
			CheckoutDate = checkoutDate;
			Duration = duration;
			Price = price;
			Email = email;
			Status = status;
		}

		public string Code { get; set; }
		public int RoomId { get; set; }
		public DateTime CheckinDate { get; set; }
		public DateTime CheckoutDate { get; set; }
		public int Duration { get; set; }
		public decimal Price { get; set; }
		public string Email { get; set; }
		public string Status { get; set; }

		public static Booking Create(Room room, string email, DateTime checkingDate, DateTime checkoutDate)
		{
			var duration = (checkoutDate - checkingDate).TotalDays;
			decimal price = (decimal)duration * room.Price;
			return new Booking(Guid.NewGuid().ToString(), room.RoomId, checkingDate, checkoutDate, (int)duration, price, email, "confirmed");
		}

		public void Cancel() 
		{
			Status = "cancel";
		}

		public string GetStatus()
		{
			return Status;
		}
	}
}
