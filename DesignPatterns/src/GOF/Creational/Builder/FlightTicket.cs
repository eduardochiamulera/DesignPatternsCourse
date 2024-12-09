namespace DesignPatterns.src.GOF.Creational.Builder
{
	public class FlightTicket
	{
		public FlightTicket(FlightTicketBuilder builder)
		{
			Airline = builder.Airline;
			FromAeroport = builder.FromAirport;
			ToAiroport = builder.ToAirport;
			FlightCode = builder.FlightCode;
			PassengerName = builder.PassengerName;
			PassengerEmail = builder.PassengerEmail;
			PassengerDocument = builder.PassengerDocument;
			PassengerGender = builder.PassengerGender;
			EmergencyContactName = builder.EmergencyContactName;
			EmergencyContactTelephone = builder.EmergencyContactTelephone;
			Seat = builder.Seat;
			CheckedBags = builder.CheckedBags;
			HasCkeckin = builder.HasCheckin;
			Terminal = builder.Terminal;
			Gate = builder.Gate;
			Priority = builder.Priority;
		}

		public string Airline { get; set; }
        public string FromAeroport { get; set; }
        public string ToAiroport { get; set; }
		public string FlightCode { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerDocument { get; set; }
        public string PassengerGender { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactTelephone { get; set; }
        public string Seat { get; set; }
        public int CheckedBags { get; set; }
        public bool HasCkeckin { get; set; }
        public string Terminal { get; set; }
        public string Gate { get; set; }
		public int Priority { get; set; }
    }
}
