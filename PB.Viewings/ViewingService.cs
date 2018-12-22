using System;
using System.Threading.Tasks;
using PB.Configuration.Interfaces;
using PB.Configuration.Configuration;
using PB.Models.Models;
using PB.Viewings.Services;
using PB.Viewings.Factories;
using PB.Viewings.Enums;

namespace PB.Viewings
{
	public class ViewingService
	{
		private IConfiguration Configuration;
		private IAdvertFactory AdvertFactory;
		private IDiaryService DiaryService;
		private IBookingService BookingService;

		public ViewingService()
		{
			Configuration = new DiaryDBConfiguration();
			AdvertFactory = new AdvertFactory(Configuration);
			DiaryService = new DiaryService(Configuration);
			BookingService = new BookingService(DiaryService);
		}

		public async Task<BookViewingResult> BookViewing(int advertId, int customerId, DateTime ViewingStartTime)
		{
			BookingDetails bookingDetails = new BookingDetails
			{
				AdvertID = advertId,
				CustomerID = customerId,
				ViewingStartTime = ViewingStartTime
			};

			bookingDetails.Advert = await AdvertFactory.GetAdvert(bookingDetails);

			if (bookingDetails.Advert == null)
			{
				return BookViewingResult.FailAdvertNotFound;
			}

			if (!bookingDetails.Advert.isOnMarket)
			{
				return BookViewingResult.FailAdvertIsOffMarket;
			}

			bookingDetails.Diary = DiaryService.GetDiary(bookingDetails.Advert, bookingDetails);

			bookingDetails.Slot = bookingDetails.Diary.CheckForAvailability(bookingDetails);

			if (bookingDetails.Slot == null)
			{
				return BookViewingResult.ViewingSlotNotFound;
			}

			if (!bookingDetails.Slot.IsBooked)
			{
				BookingService.BookSlot(bookingDetails);

				return BookViewingResult.Success;
			} 
			else
			{
				await BookingService.RequestBooking(bookingDetails);

				return BookViewingResult.ViewingRequested;
			}
			
		}
	}
}