using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Viewings.Helpers
{
	public static class URLHelper
	{
		/// <summary>
		/// Appends id to AdvertApi Urls
		/// </summary>
		/// <param name="p_advertApiUrl"></param>
		/// <param name="p_advertID"></param>
		/// <returns></returns>
		public static string AppendAdvertIDToAPIUrl(string p_advertApiUrl, int p_advertID)
		{
			return p_advertApiUrl.TrimEnd('/') + '/' + p_advertID;
		}
	}
}
