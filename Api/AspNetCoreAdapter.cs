using DesignPatterns.src.GOF.Structural.Adapter.Catalog;

namespace Api
{
	public class AspNetCoreAdapter : IHttpServer
	{
		private readonly WebApplication _app;

		public AspNetCoreAdapter(WebApplication app)
		{
			_app = app;
		}

		public void Register(string method, string url, Func<RouteValueDictionary, Task<object>> callback)
		{
			_app.MapGet(url, async (HttpContext context) =>
			{
				var routeValues = context.Request.RouteValues;
				var result = await callback(routeValues);
				return result;
			});
		}

		public void Listen(int port)
		{
			_app.Run($"http://localhost:{port}");
		}
	}
}
