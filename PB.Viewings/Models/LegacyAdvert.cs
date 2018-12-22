using PB.Viewings.Enums;
using System.Runtime.Serialization;

namespace PB.Viewings.Models
{
    [DataContract]
    public class LegacyAdvert
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public LegacyAdvertStatus status { get; set; }

        [DataMember]
        public bool accompaniedViewings { get; set; }
    }
}