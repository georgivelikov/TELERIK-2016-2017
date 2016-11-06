using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModels
{
    [Serializable]
    [XmlType("Friendship")]
    public class XmlFriendship
    {
        [XmlAttribute]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public XmlUser FirstUser { get; set; }

        public XmlUser SecondUser { get; set; }

        [XmlArrayItem(ElementName = "Message")]
        public List<XmlMessage> Messages { get; set; }
    }
}
