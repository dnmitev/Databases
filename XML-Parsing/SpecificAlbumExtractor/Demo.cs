// 11. Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier. 
// Use XPath query.


// 12. Rewrite the previous using LINQ query.

namespace SpecificAlbumExtractor
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    internal class Demo
    {
        private static void Main()
        {
            string filePath = "../../../catalog.xml";

            GetPriceListWithXpath(filePath);

            Console.WriteLine("\n\n\n");

            GetPriceListWithLinq(filePath);
        }
 
        private static void GetPriceListWithLinq(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);

            var priceList = doc.Descendants("album")
                               .Where(x => int.Parse(x.Element("year").Value) <= 2009)
                               .Select(x => x.Element("price"));

            foreach (var price in priceList)
            {
                Console.WriteLine(price.Value);
            }
        }
 
        private static void GetPriceListWithXpath(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            string query = "//album[year<2009]/price";
            XmlNodeList priceList = doc.SelectNodes(query);

            foreach (XmlNode album in priceList)
            {
                Console.WriteLine(album.InnerText);
            }
        }
    }
}