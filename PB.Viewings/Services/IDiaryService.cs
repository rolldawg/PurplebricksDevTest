using PB.Models.Models;

namespace PB.Viewings.Services
{
	public interface IDiaryService
	{
		/// <summary>
		/// Gets appropriate diary record based on advert.
		/// </summary>
		/// <param name="p_advert"></param>
		/// <param name="p_bookingDetails"></param>
		/// <returns></returns>
		Diary GetDiary(Advert p_advert, BookingDetails p_bookingDetails);

		/// <summary>
		/// Books a viewing
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		void BookViewing(BookingDetails p_bookingDetails);

		/// <summary>
		/// Requests a booking
		/// </summary>
		void RequestBooking(BookingDetails p_bookingDetails);
	}
}
