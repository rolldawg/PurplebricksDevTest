using PB.Configuration.Interfaces;
using PB.Models.Models;
using PB.Viewings.Enums;
using PB.Viewings.Helpers;
using PB.Viewings.Models;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace PB.Viewings.Services
{
	/// <summary>
	/// Legacy Advert API implementation
	/// </summary>
	public class LegacyAdvertClient
	{
		private IConfiguration Configuration;

		public LegacyAdvertClient(IConfiguration p_configuration)
		{
			Configuration = p_configuration;
		}

		public Advert Get(int advertId)
		{
			using (var httpClient = new HttpClient())
			{
				var response = httpClient
								.GetAsync(URLHelper.AppendAdvertIDToAPIUrl(Configuration.GetLegacyAdvertApi(), advertId))
								.GetAwaiter()
								.GetResult();
				
				var stream1 = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
				DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(LegacyAdvert));  
			
				 stream1.Position = 0;  
				var advert = (LegacyAdvert)ser.ReadObject(stream1);
				
				return MapLegacyAdvertToAdvert(advert);
			};
		}

		public Advert MapLegacyAdvertToAdvert(LegacyAdvert la)
		{
			var advert = new Advert();
			advert.id = la.id;
			advert.hasAccompaniedViewings = la.accompaniedViewings;
			advert.isOnMarket = true;

			if (la.status == LegacyAdvertStatus.OffMarket)
			{
				advert.isOnMarket = false;
			}

			return advert;
		}
	}
}