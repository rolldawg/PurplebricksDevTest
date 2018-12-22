using System;
using System.Collections.Generic;
using System.Linq;

namespace PB.Models.Models
{
    public class Diary
    {
        public IEnumerable<Slot> Slots { get; set; }

		public Diary()
		{
			Slots = new List<Slot>();
		}

		/// <summary>
		/// Checks if there is an available slot is booked in the Slots object
		/// </summary>
		/// <param name="p_bookingDetails"></param>
		/// <returns></returns>
		public Slot CheckForAvailability(BookingDetails p_bookingDetails)
		{
			Slot slot = this.Slots.Where(x => IsDateEqual(x.StartTime, p_bookingDetails.ViewingStartTime)).DefaultIfEmpty(null).First();

			return slot;
		}

		/// <summary>
		/// Checks if both dates are equal.
		/// </summary>
		/// <param name="p_dateTimeOne"></param>
		/// <param name="p_dateTimeTwo"></param>
		/// <returns></returns>
		private bool IsDateEqual(DateTime p_dateTimeOne, DateTime p_dateTimeTwo)
		{
			DateTime d1 = new DateTime(p_dateTimeOne.Year, p_dateTimeOne.Month, p_dateTimeOne.Day, p_dateTimeOne.Hour, p_dateTimeOne.Minute, 0);
			DateTime d2 = new DateTime(p_dateTimeTwo.Year, p_dateTimeTwo.Month, p_dateTimeTwo.Day, p_dateTimeTwo.Hour, p_dateTimeTwo.Minute, 0);

			return d1.CompareTo(d2) == 0;
		}
    }
}