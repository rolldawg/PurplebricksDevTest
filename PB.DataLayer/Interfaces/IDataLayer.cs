namespace PB.DataLayer.Interfaces
{
	/// <summary>
	/// Interface that has all the contract for the DataLayer.
	/// </summary>
	public interface IDataLayer
	{
		/// <summary>
		/// Contract for all Stored Procedures to the database
		/// </summary>
		IProcedures Procedures { get; set; }

		/// <summary>
		/// Contract which contains all methods that use raw SQL to interact with the Diary DB
		/// </summary>
		IDiary Diary { get; set; }
	}
}
