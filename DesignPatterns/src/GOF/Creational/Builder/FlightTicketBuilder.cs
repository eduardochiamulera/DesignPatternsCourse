namespace DesignPatterns.src.GOF.Creational.Builder
{
	public class FlightTicketBuilder
	{
		public string Airline { get; set; } = null!;
		public string FlightCode { get; set; } = null!;
		public string FromAirport { get; set; } = null!;
		public string ToAirport { get; set; } = null!;
		public string PassengerName { get; set; } = null!;
		public string PassengerEmail { get; set; } = null!;
		public string PassengerDocument { get; set; } = null!;
		public string PassengerGender { get; set; } = null!;
		public string EmergencyContactName { get; set; } = null!;
		public string EmergencyContactTelephone { get; set; } = null!;
		public string Seat { get; set; } = null!;
		public int CheckedBags { get; set; }
		public bool HasCheckin { get; set; }
		public string Terminal { get; set; } = null!;
		public string Gate { get; set; } = null!;
		public int Priority { get; set; }

		public FlightTicketBuilder SetFlight(string airline, string code)
		{
			Airline = airline;
			FlightCode = code;
			return this;
		}

		public FlightTicketBuilder SetTrip(string from, string to)
		{
			FromAirport = from;
			ToAirport = to;
			return this;
		}

		public FlightTicketBuilder SetPassanger(string name, string email, string document, string gender)
		{
			PassengerDocument = document;
			PassengerGender = gender;
			PassengerName = name;
			PassengerEmail = email;
			return this;
		}

		public FlightTicketBuilder SetEmergencyContact(string name, string telephone)
		{
			EmergencyContactName = name;
			EmergencyContactTelephone = telephone;
			return this;
		}

		public FlightTicketBuilder SetSeat(string seat)
		{
			Seat = seat;
			return this;
		}

		public FlightTicketBuilder SetCheckedBags(int checkedBags)
		{
			CheckedBags = checkedBags;
			return this;
		}

		public FlightTicketBuilder SetCheckinInformation(bool hasCheckin, string terminal, string gate)
		{
			HasCheckin = hasCheckin;
			Terminal = terminal;
			Gate = gate;
			return this;

		}
		
		public FlightTicketBuilder SetPriority(int priority)
		{
			Priority = priority;
			return this;
		}

		public FlightTicket GetFlightTicket()
		{
			return new FlightTicket(this);
		}
	}
}
