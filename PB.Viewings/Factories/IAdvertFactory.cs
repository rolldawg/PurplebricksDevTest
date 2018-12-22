using PB.Models.Models;
using System.Threading.Tasks;

namespace PB.Viewings.Factories
{
	/// <summary>
	/// Interface that has the contract for all types of Advert API calls
	/// </summary>
	public interface IAdvertFactory
	{
		/// <summary>
		/// Gets the Advert record given the advert id.
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		/// <returns></returns>
		Task<Advert> GetAdvert(BookingDetails p_bookingDetails);
	}
}
