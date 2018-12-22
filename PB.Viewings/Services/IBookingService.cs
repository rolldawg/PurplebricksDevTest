using PB.Models.Models;
using System.Threading.Tasks;

namespace PB.Viewings.Services
{
	public interface IBookingService
	{
		/// <summary>
		/// Book a slot
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		void BookSlot(BookingDetails p_bookingDetails);

		/// <summary>
		/// Rquest a booking
		/// </summary>
		/// <param name="bookingDetails"></param>
		/// <returns></returns>
		Task RequestBooking(BookingDetails bookingDetails);
	}
}
