// 05. Write a program, which using XmlReader extracts all song titles from catalog.xml.
// 06. Rewrite the same using XDocument and LINQ query.

namespace SongsExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            ExtractSongTitlesWithXmlReader();

            Console.WriteLine("Press any key to extract songs again using XDocument...");
            Console.ReadLine();

            ExtractSongsWithXDocument();
        }
 
        private static void ExtractSongsWithXDocument()
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            var songsByTitle = doc.Descendants("songName");

            foreach (var song in songsByTitle)
            {
                Console.WriteLine(song.Value);
            }
        }
 
        private static void ExtractSongTitlesWithXmlReader()
        {
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "songName")
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
}