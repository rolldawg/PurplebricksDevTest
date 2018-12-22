using PB.Configuration.Interfaces;
using System;
using System.Configuration;

namespace PB.Configuration.Configuration
{
	public class DiaryDBConfiguration : IConfiguration
	{
		/// <summary>
		/// Gets the DiaryDatabase Connection string
		/// </summary>
		/// <returns></returns>
		public string GetDatabaseConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["DiaryDatbse.ConnectionString"].ConnectionString;
		}
		
		/// <summary>
		/// Gets the Advert api string
		/// </summary>
		/// <returns></returns>
		public string GetAdvertApi()
		{
			return ConfigurationManager.AppSettings["AdvertAPI"];
		}

		/// <summary>
		/// Gets the LegacyAdvert api string
		/// </summary>
		/// <returns></returns>
		public string GetLegacyAdvertApi()
		{
			return ConfigurationManager.AppSettings["LegacyAdvertApi"];
		}

		/// <summary>
		/// Gets the Database Connection string
		/// </summary>
		/// <returns></returns>
		public bool UseNewAdvertApi()
		{
			string conf = ConfigurationManager.AppSettings["FeatureToggle.UseNewAdvertApi"];

			Boolean.TryParse(conf, out bool value);

			return value;
		}
	}
}
