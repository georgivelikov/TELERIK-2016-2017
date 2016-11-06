using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Task16
{
    public class Start
    {
        public static void Main()
        {
            var xmlFilePath = "../../simple-catalog.xml";
            var xsdFilePath = "../../simple-catalog.xsd";
            var invalidXmlFilePath = "../../invalid-catalog.xml";

            Console.WriteLine(IsValidXml(xmlFilePath, xsdFilePath));
            Console.WriteLine(IsValidXml(invalidXmlFilePath, xsdFilePath));
        }

        public static bool IsValidXml(string xmlFilePath, string xsdFilePath)
        {
            var xdoc = XDocument.Load(xmlFilePath);
            var schemas = new XmlSchemaSet();
            schemas.Add(null, xsdFilePath);

            Boolean result = true;
            xdoc.Validate(schemas, (sender, e) =>
            {
                result = false;
            });

            return result;
        }


    }
}
