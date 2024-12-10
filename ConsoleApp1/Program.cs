using DesignPatterns.src.GOF.Structural.Flyweight;
var tickets = new List<LotteryTicket>();
GC.Collect();
long memoryBefore = GC.GetTotalMemory(true);

foreach (string line in File.ReadLines("C:\\Users\\eduar\\source\\repos\\test\\ConsoleApp1\\bin\\Debug\\net8.0\\loteria_timespan.csv"))
{
	var parts = line.Split(",");
	string? draw = parts[0];
	string? date = parts[1];
	string? b1 = parts[2];
	string? b2 = parts[3];
	string? b3 = parts[4];
	string? b4 = parts[5];
	string? b5 = parts[6];
	string? b6 = parts[7];

	var ticket = new LotteryTicket(FlyweightFactory.Get(draw, int.Parse(date)), b1, b2, b3, b4, b5, b6);
	//var ticket = new LotteryTicket(new DrawFlyweight(draw, int.Parse(date)), b1, b2, b3, b4, b5, b6);
	tickets.Add(ticket);
}

long memoryAfter = GC.GetTotalMemory(true);
long memoryUsed1 = memoryAfter - memoryBefore;
Console.WriteLine($"Memória usada pela primeira implementação: {memoryUsed1} bytes");