namespace DesignPatterns.src.GOF.Structural.Adapter.Catalog
{
	public interface IHttpServer
	{
		void Register(string method, string url, Func<RouteValueDictionary, Task<object>> callback);
		void Listen(int port);
	}
}
