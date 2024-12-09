using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace DesignPatterns.src.GOF.Structural.Adapter.Checkout
{
	public interface HttpClientApadter
	{
		Task<string> GetAsync(string url);
		Task<string> PostAsync(string url, object body);
	}

	public class HttpClientAdapter : HttpClientApadter
	{
		public async Task<string> GetAsync(string url)
		{
			using (var httpClient = new HttpClient())
			{
				var response = await httpClient.GetAsync(url);

				var content = await response.Content.ReadAsStringAsync();

				return content;
			}
		}

		public async Task<string> PostAsync(string url, object body)
		{
			using (var httpClient = new HttpClient())
			{
				var requestContent = JsonConvert.SerializeObject(body);

				var response = await httpClient.PostAsync(url, new StringContent( requestContent, Encoding.UTF8, "application/json") );

				var content = await response.Content.ReadAsStringAsync();

				return content;
			}
		}
	}
}
