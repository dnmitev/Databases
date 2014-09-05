// 08. Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml and creates the file album.xml, in 
// which stores in appropriate way the names of all albums and their authors.

namespace AlbumXmlCreator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    class Demo
    {
        static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter("../../albums.xml",Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");

                using (XmlReader reader = XmlReader.Create("../../.../catalog.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                        {
                            var albumTitle = reader.ReadElementString();

                            reader.Read();

                            var artist = reader.ReadElementString();

                            writer.WriteStartElement("album");
                            writer.WriteElementString("albumTitle",albumTitle);
                            writer.WriteElementString("artist",artist);
                            writer.WriteEndElement();
                        }
                    }
                }

                writer.WriteEndElement();
            }
        }
    }
}
