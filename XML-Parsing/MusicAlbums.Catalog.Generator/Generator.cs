// 01. Create a XML file representing catalogue. The catalogue should contain albums of different artists. For each album you 
// should define: name, artist, year, producer, price and a list of songs. Each song should be described by title and duration.

namespace MusicAlbums.Catalog.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    public class Generator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random randomGenerator = new Random();

        private static void Main()
        {
            string fileName = "catalog";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            XmlTextWriter writer = new XmlTextWriter(string.Format("../../../{0}.xml", fileName), encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("catalog");
                writer.WriteAttributeString("name", "music albums catalog");

                writer.WriteStartElement("albums");

                for (int i = 0; i < 20; i++)
                {
                    AddAlbum(writer,
                        GetRandomString(10),
                        GetRandomString(20),
                        GetRandomNumber(1970, 2014),
                        GetRandomString(5),
                        GetRandomPrice(1.97, 19.97),
                        new List<string>()
                        {
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString(),
                            GetRandomString()
                        });
                }
            }
        }

        private static void AddAlbum(XmlWriter writer,
            string title,
            string artist,
            int year,
            string producer,
            decimal price,
            IList<string> songs)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("title", title);
            writer.WriteElementString("artist", artist);
            writer.WriteElementString("year", year.ToString());
            writer.WriteElementString("producer", producer);
            writer.WriteElementString("price", price.ToString("0.00"));

            writer.WriteStartElement("songs");

            foreach (var song in songs)
            {
                writer.WriteElementString("songName", song);
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
        }

        private static string GetRandomString(int length = 5)
        {
            char[] generatedString = new char[length];

            for (int i = 0; i < generatedString.Length; i++)
            {
                generatedString[i] = Alphabet[randomGenerator.Next(0, Alphabet.Length)];
            }

            return string.Join(string.Empty, generatedString);
        }

        private static int GetRandomNumber(int min, int max)
        {
            return randomGenerator.Next(min, max + 1);
        }

        private static decimal GetRandomPrice(double min, double max)
        {
            var numberGenerated = randomGenerator.NextDouble();

            return (decimal)(min + (numberGenerated * (max - min)));
        }
    }
}