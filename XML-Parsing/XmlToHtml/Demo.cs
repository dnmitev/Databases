// 14. an XSL stylesheet, which transforms the file catalog.xml into HTML document, formatted for viewing in a standard Web-browser.

namespace XmlToHtml
{
    using System;
    using System.Linq;
    using System.Xml.Xsl;
    
    internal class Demo
    {
        private static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../catalog.xsl");
            xslt.Transform("../../../catalog.xml", "../../../catalog.html");
        }
    }
}