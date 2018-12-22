using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using PB.Configuration.Interfaces;
using PB.Viewings.Helpers;
using PB.Models.Models;

namespace PB.Viewings.Services
{
	/// <summary>
	/// New Advert API implementation
	/// </summary>
	public class AdvertClient
	{
		private IConfiguration Configuration;

		public AdvertClient(IConfiguration p_configuration)
		{
			Configuration = p_configuration;
		}

		public async Task<Advert> GetById(int advertId)
		{
			var advertApi = Configuration.GetAdvertApi();
			var httpClient = new HttpClient();

			var response = await httpClient.GetAsync(URLHelper.AppendAdvertIDToAPIUrl(advertApi, advertId));
			var stream1 = await response.Content.ReadAsStreamAsync();
			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Advert));  
			
			stream1.Position = 0;  
			var advert = (Advert)ser.ReadObject(stream1);
			
			stream1.Dispose();
			httpClient.Dispose();
			return advert;
		}
	}
}