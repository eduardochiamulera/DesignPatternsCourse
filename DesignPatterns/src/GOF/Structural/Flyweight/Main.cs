namespace DesignPatterns.src.GOF.Structural.Flyweight
{
	public class LotteryTicket
	{
		public LotteryTicket(DrawFlyweight draw, string bet1, string bet2, string bet3, string bet4, string bet5, string bet6)
		{
			Draw = draw;
			Bet1 = bet1;
			Bet2 = bet2;
			Bet3 = bet3;
			Bet4 = bet4;
			Bet5 = bet5;
			Bet6 = bet6;
		}

		public DrawFlyweight Draw {  get; set; }
        public string Bet1 { get; set; }
        public string Bet2 { get; set; }
        public string Bet3 { get; set; }
        public string Bet4 { get; set; }
        public string Bet5 { get; set; }
        public string Bet6 { get; set; }
    }

	public class DrawFlyweight
	{
		public DrawFlyweight(string draw, int date)
		{
			Draw = draw;
			Date = Date = new DateTime(2020, 1, 1).AddDays(date);
		}

		public string Draw { get; set; }
		public DateTime Date { get; set; }
	}

	public class FlyweightFactory
	{
		public static Dictionary<string, DrawFlyweight> cache = new Dictionary<string, DrawFlyweight>();

		public static DrawFlyweight Get(string draw, int date)
		{
			var index = $"{draw}:${date}";

			if (!cache.ContainsKey(index))
			{
				cache.Add(index, new DrawFlyweight(draw, date));
			}

			return cache[index];
		}
	}
}
