using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlModels
{
    [Serializable]
    public class XmlUser
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }    

        [XmlArrayItem(ElementName = "Image")]
        public List<XmlImage> Images { get; set; }
    }
}
