using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PB.Models.Models;

namespace PB.Test.PB.Models
{
	[TestClass]
	public class DiaryTest
	{
		[TestMethod]
		public void Test_CheckForAvailability_HasSlotAvailable()
		{
			DateTime dateOne = DateTime.Now;
			DateTime dateTwo = DateTime.Now.AddDays(1);
			DateTime dateThree = DateTime.Now.AddDays(2);

			List<Slot> slots = new List<Slot>()
			{
				new Slot { IsBooked = false, StartTime = dateOne},
				new Slot { IsBooked = false, StartTime = dateTwo},
				new Slot { IsBooked = false, StartTime = dateThree}
			};

			Diary diary = new Diary();
			diary.Slots = slots;

			BookingDetails bookingDetails = new BookingDetails()
			{
				ViewingStartTime = dateOne
			};

			Slot slot = diary.CheckForAvailability(bookingDetails);

			Assert.IsNotNull(slot);
			Assert.IsFalse(slot.IsBooked);
			Assert.IsTrue(IsDateEqual(dateOne, slot.StartTime));
		}

		[TestMethod]
		public void Test_CheckForAvailability_HasNoSlotAvailable_ShouldReturnNull()
		{
			DateTime dateOne = DateTime.Now;
			DateTime dateTwo = DateTime.Now.AddDays(1);
			DateTime dateThree = DateTime.Now.AddDays(2);

			List<Slot> slots = new List<Slot>()
			{
				new Slot { IsBooked = false, StartTime = dateOne},
				new Slot { IsBooked = false, StartTime = dateTwo},
				new Slot { IsBooked = false, StartTime = dateThree}
			};

			Diary diary = new Diary();
			diary.Slots = slots;

			BookingDetails bookingDetails = new BookingDetails()
			{
				ViewingStartTime = DateTime.Now.AddDays(500)
			};

			Slot slot = diary.CheckForAvailability(bookingDetails);

			Assert.IsNull(slot);
		}

		[TestMethod]
		public void Test_CheckForAvailability_SlotsNotSet_ShouldReturnNull()
		{
			Diary diary = new Diary();

			BookingDetails bookingDetails = new BookingDetails()
			{
				ViewingStartTime = DateTime.Now.AddDays(500)
			};

			Slot slot = diary.CheckForAvailability(bookingDetails);

			Assert.IsNull(slot);
		}

		[TestMethod]
		public void Test_CheckForAvailability_HasDuplicateDates_ShouldReturnOneSlot()
		{
			DateTime dateOne = DateTime.Now;
			DateTime dateTwo = dateOne;
			DateTime dateThree = DateTime.Now.AddDays(2);

			List<Slot> slots = new List<Slot>()
			{
				new Slot { IsBooked = false, StartTime = dateOne},
				new Slot { IsBooked = false, StartTime = dateTwo},
				new Slot { IsBooked = false, StartTime = dateThree}
			};

			Diary diary = new Diary();
			diary.Slots = slots;

			BookingDetails bookingDetails = new BookingDetails()
			{
				ViewingStartTime = dateOne
			};

			Slot slot = diary.CheckForAvailability(bookingDetails);

			Assert.IsNotNull(slot);
			Assert.IsFalse(slot.IsBooked);
			Assert.IsTrue(IsDateEqual(dateOne, slot.StartTime));
		}

		[TestMethod]
		public void Test_CheckForAvailability_HasDuplicateDatesButDifferentIsBookedField_ShouldReturnFirstSlot()
		{
			DateTime dateOne = DateTime.Now;
			DateTime dateTwo = dateOne;
			DateTime dateThree = DateTime.Now.AddDays(2);

			List<Slot> slots = new List<Slot>()
			{
				new Slot { IsBooked = false, StartTime = dateOne},
				new Slot { IsBooked = true, StartTime = dateTwo},
				new Slot { IsBooked = false, StartTime = dateThree}
			};

			Diary diary = new Diary();
			diary.Slots = slots;

			BookingDetails bookingDetails = new BookingDetails()
			{
				ViewingStartTime = dateOne
			};

			Slot slot = diary.CheckForAvailability(bookingDetails);

			Assert.IsNotNull(slot);
			Assert.IsFalse(slot.IsBooked);
			Assert.IsTrue(IsDateEqual(dateOne, slot.StartTime));
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
