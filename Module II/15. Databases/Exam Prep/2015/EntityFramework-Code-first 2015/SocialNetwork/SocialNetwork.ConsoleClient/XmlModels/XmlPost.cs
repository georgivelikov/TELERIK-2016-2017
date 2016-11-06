using System;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModels
{
    [Serializable]
    [XmlType("Post")]
    public class XmlPost
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
