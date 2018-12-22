namespace PB.Configuration.Interfaces
{
	public interface IConfiguration
	{
		/// <summary>
		/// Gets the Database Connection string
		/// </summary>
		/// <returns></returns>
		string GetDatabaseConnectionString();

		/// <summary>
		/// Gets the Advert api string
		/// </summary>
		/// <returns></returns>
		string GetAdvertApi();

		/// <summary>
		/// Gets the LegacyAdvert api string
		/// </summary>
		/// <returns></returns>
		string GetLegacyAdvertApi();

		/// <summary>
		/// Tells the program whether to use new Advert API or not
		/// </summary>
		/// <returns></returns>
		bool UseNewAdvertApi();
	}
}
