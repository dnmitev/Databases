// 02. Write program that extracts all different artists which are found in the catalog.xml. For each author you should print 
// the number of albums in the catalogue. Use the DOM parser and a hash-table.

// 03. Implement the previous using XPath

namespace ArtistsExtracotr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class Demo
    {
        private static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            
            ParseArtistWithDomParser(doc);

            Console.WriteLine("Press any key to parse DOM with XPath...");
            Console.ReadLine();

            ParseArtistsWithXPath(doc);
        }
 
        private static void ParseArtistsWithXPath(XmlDocument doc)
        {
            var distinctArtists = new Dictionary<string, int>();

            string pathQuery = "//artist";
            XmlNodeList artists = doc.SelectNodes(pathQuery);

            foreach (XmlNode artist in artists)
            {
                if (!distinctArtists.ContainsKey(artist.InnerText))
                {
                    distinctArtists[artist.InnerText] = 0;
                }

                distinctArtists[artist.InnerText]++;
            }

            PrintArtists(distinctArtists);
        }
 
        private static void ParseArtistWithDomParser(XmlDocument doc)
        {
            var distinctArtists = new Dictionary<string, int>();

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                foreach (XmlNode album in node.ChildNodes)
                {
                    if (!distinctArtists.ContainsKey(album["artist"].InnerText))
                    {
                        distinctArtists[album["artist"].InnerText] = 0;
                    }

                    distinctArtists[album["artist"].InnerText]++;
                }
            }

            PrintArtists(distinctArtists);
        }
 
        private static void PrintArtists(Dictionary<string, int> distinctArtists)
        {
            foreach (var artist in distinctArtists)
            {
                Console.WriteLine("{0} -> {1}", artist.Key, artist.Value);
            }
        }
    }
}