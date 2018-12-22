using System;
using System.Threading.Tasks;
using PB.Models.Models;
using PB.ServiceBus;

namespace PB.Viewings.Services
{
	public class BookingService : IBookingService
	{
		private IDiaryService DiaryService;

		public BookingService(IDiaryService p_diaryService)
		{
			DiaryService = p_diaryService;
		}

		/// <summary>
		/// Book a slot
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		public void BookSlot(BookingDetails p_bookingDetails)
		{
			DiaryService.BookViewing(p_bookingDetails);

			// Publish event
			var p = new EventPublisher();
			p.PublishEvent(new ViewingBookedV1()
			{
				Slot = p_bookingDetails.Slot.StartTime,
				AdvertId = p_bookingDetails.AdvertID,
				CustomerId = p_bookingDetails.CustomerID,
				TimeStampUtc = DateTime.UtcNow
			}).GetAwaiter().GetResult();
		}

		/// <summary>
		/// Rquest a booking
		/// </summary>
		/// <param name="bookingDetails"></param>
		/// <returns></returns>
		public async Task RequestBooking(BookingDetails p_bookingDetails)
		{
			DiaryService.RequestBooking(p_bookingDetails);

			// Publish event
			var p = new EventPublisher();
			await p.PublishEvent(new ViewingRequestedV1()
			{
				Slot = p_bookingDetails.Slot.StartTime,
				AdvertId = p_bookingDetails.AdvertID,
				CustomerId = p_bookingDetails.CustomerID,
				TimeStampUtc = DateTime.UtcNow
			});
		}
	}
}
