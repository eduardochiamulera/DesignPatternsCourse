namespace DesignPatterns.src.GOF.Behavioral.Mediator
{
	public class Mediator
	{

		private readonly List<EventHandler> _handlers;

		public Mediator()
		{
			_handlers = new List<EventHandler>();
		}

		public void Register(string eventName, Func<object, Task> callback)
		{
			_handlers.Add(new EventHandler(eventName, callback));
		}

		public async Task NotifyAsync(string eventName, object data)
		{
			var eventHandlers = _handlers.Where(h => h.EventName == eventName);
			foreach (var handler in eventHandlers)
			{
				await handler.Callback(data);
			}
		}

		private class EventHandler
		{
			public string EventName { get; }
			public Func<object, Task> Callback { get; }

			public EventHandler(string eventName, Func<object, Task> callback)
			{
				EventName = eventName;
				Callback = callback;
			}
		}
	}
}
