using System.Xml.Xsl;

namespace Task14
{
    public class Start
    {
        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            var xsltPath = "../../../catalog.xslt";
            var xmlPath = "../../../catalog.xml";
            var outputHtmlPath = "../../../catalog.html";
            xslt.Load(xsltPath);

            xslt.Transform(xmlPath, outputHtmlPath);
        }
    }
}
