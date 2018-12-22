using PB.Configuration.Interfaces;
using PB.Models.Models;
using PB.Viewings.Services;
using System.Threading.Tasks;

namespace PB.Viewings.Factories
{
	/// <summary>
	/// This class handles which Advert API to use, be it the legacy system or the new one.
	/// </summary>
	public class AdvertFactory : IAdvertFactory
	{
		private AdvertClient AdvertClient;
		private LegacyAdvertClient LegacyAdvertClient;

		IConfiguration Configuration;

		public AdvertFactory(IConfiguration p_configuration)
		{
			Configuration = p_configuration;
			AdvertClient = new AdvertClient(p_configuration);
			LegacyAdvertClient = new LegacyAdvertClient(p_configuration);
		}

		/// <summary>
		/// Gets the Advert record given the advert id.
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		/// <returns></returns>
		public async Task<Advert> GetAdvert(BookingDetails p_bookingDetails)
		{
			Advert returnValue;

			if (Configuration.UseNewAdvertApi())
			{
				returnValue = await AdvertClient.GetById(p_bookingDetails.AdvertID);
			} else
			{
				returnValue = LegacyAdvertClient.Get(p_bookingDetails.AdvertID);
			}

			return returnValue;
		}
	}
}
