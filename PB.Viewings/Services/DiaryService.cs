using System;
using PB.Configuration.Interfaces;
using PB.DataLayer.Database;
using PB.DataLayer.Interfaces;
using PB.Models.Models;

namespace PB.Viewings.Services
{
	public class DiaryService : IDiaryService
	{
		private IDataLayer DataLayer;

		public DiaryService(IConfiguration p_configuration)
		{
			DataLayer = new DatabaseLayer(p_configuration);
		}

		/// <summary>
		/// Gets appropriate diary record based on advert.
		/// </summary>
		/// <param name="p_advert"></param>
		/// <param name="p_bookingDetails"></param>
		/// <returns></returns>
		public Diary GetDiary(Advert p_advert, BookingDetails p_bookingDetails)
		{
			if (p_advert.hasAccompaniedViewings)
			{
				// get AVLPE diary
				return DataLayer.Procedures.FindAVLPEDiary(p_bookingDetails.CustomerID, p_bookingDetails.ViewingStartTime.Year, p_bookingDetails.ViewingStartTime.Month, p_bookingDetails.ViewingStartTime.Day);
			}
			else
			{
				// get customer diary
				return DataLayer.Procedures.FindCustomerDiary(p_bookingDetails.CustomerID, p_bookingDetails.ViewingStartTime.Year, p_bookingDetails.ViewingStartTime.Month, p_bookingDetails.ViewingStartTime.Day);
			}
		}

		/// <summary>
		/// Books a viewing
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		public void BookViewing(BookingDetails p_bookingDetails)
		{
			DataLayer.Procedures.BookViewing(p_bookingDetails.CustomerID, p_bookingDetails.AdvertID, p_bookingDetails.Slot, p_bookingDetails.Advert.hasAccompaniedViewings);
		}

		/// <summary>
		/// Requests a booking
		/// </summary>
		public void RequestBooking(BookingDetails p_bookingDetails)
		{
			throw new NotImplementedException();
		}

	}
}
