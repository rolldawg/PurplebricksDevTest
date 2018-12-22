using System.Runtime.Serialization;

namespace PB.Models.Models
{
    [DataContract]
    public class Advert
    {
        [DataMember]
        public int id { get; set; }
        
        [DataMember]
        public bool isOnMarket { get; set; }
        
        [DataMember]
        public bool hasAccompaniedViewings { get; set; }
    }
}