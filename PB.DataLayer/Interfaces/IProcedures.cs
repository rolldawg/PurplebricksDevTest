using PB.Models.Models;

namespace PB.DataLayer.Interfaces
{
	/// <summary>
	/// Interface that has the contract for all stored procedures.
	/// </summary>
	public interface IProcedures
	{
		/// <summary>
		/// Gets the AVLPE diary
		/// </summary>
		/// <param name="advertId"></param>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		Diary FindAVLPEDiary(int advertId, int year, int month, int day);

		/// <summary>
		/// Gets the Customer Diary
		/// </summary>
		/// <param name="propertyId"></param>
		/// <param name="year"></param>
		/// <param name="month"></param>
		/// <param name="day"></param>
		/// <returns></returns>
		Diary FindCustomerDiary(int propertyId, int year, int month, int day);

		/// <summary>
		/// Book a viewing
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="advertId"></param>
		/// <param name="slot"></param>
		/// <param name="hasAccompanied"></param>
		void BookViewing(int customerId, int advertId, Slot slot, bool hasAccompanied);
	}
}
