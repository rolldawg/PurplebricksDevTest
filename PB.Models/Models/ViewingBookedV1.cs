using System;

namespace PB.Models.Models
{
    public class ViewingBookedV1
    {
        public DateTime TimeStampUtc { get; set; }

        public int CustomerId { get; set; }

        public int AdvertId { get; set; }

        public DateTime Slot { get; set; }
    }
}