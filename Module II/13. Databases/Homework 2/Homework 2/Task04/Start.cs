using System.Xml;

namespace Task04
{
    using System.Collections.Generic;

    public class Start
    {
        public static void Main()
        {
            const decimal MaxPrice = 20m;
            var doc = new XmlDocument();
            var path = "../../catalog-to-delete-test.xml";
            // var path = "../../catalog-to-delete.xml";
            doc.Load(path);

            XmlNode rootNode = doc.DocumentElement;
            var nodesToDelete = new List<XmlNode>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentPrice = decimal.Parse(node["price"].InnerText.Trim());
                if (currentPrice > MaxPrice)
                {
                    nodesToDelete.Add(node);
                }
            }

            for (int i = 0; i < nodesToDelete.Count; i++)
            {
                rootNode.RemoveChild(nodesToDelete[i]);
            }

            doc.Save(path);
        }
    }
}
