using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Models.Models
{
	public class BookingDetails
	{
		public int AdvertID { get; set; }

		public Advert Advert { get; set; }

		public int CustomerID { get; set; }

		public DateTime ViewingStartTime { get; set; }

		public Diary Diary { get; set; }

		public Slot Slot { get; set; }
	}
}
