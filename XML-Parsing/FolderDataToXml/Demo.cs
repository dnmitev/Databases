// 09. Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
//Use tags <file> and <dir> with appropriate attributes. For the generation of the XML document use the class XmlWriter.

namespace FolderDataToXml
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    internal class Demo
    {
        private static void Main()
        {
            string folderPath = "../../";
            string outputXml = "../../folderData.xml";

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            Encoding encoding = Encoding.UTF8;

            GetDirectoryDataUsingXmlWriter(outputXml, encoding, dirInfo);

            var doc = new XDocument(GetDirectoryDataWithLinq(dirInfo));
            doc.Save("../../folderData2.xml");
        }

        private static XElement GetDirectoryDataWithLinq(DirectoryInfo dirInfo)
        {
            var root = new XElement("dirs");
            var info = new XElement("dir", new XAttribute("dir", dirInfo.Name));

            root.Add(info);

            foreach (var file in dirInfo.GetFiles())
            {
                info.Add(new XElement("file", file.Name));
            }

            foreach (var subDir in dirInfo.GetDirectories())
            {
                info.Add(GetDirectoryDataWithLinq(subDir));
            }

            return root;
        }
 
        private static void GetDirectoryDataUsingXmlWriter(string outputXml, Encoding encoding, DirectoryInfo dirInfo)
        {
            using (XmlTextWriter writer = new XmlTextWriter(outputXml,encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("dirs");

                BuildXmlData(writer, dirInfo);

                writer.WriteEndDocument();
            }
        }

        private static void BuildXmlData(XmlTextWriter writer, DirectoryInfo dirInfo)
        {
            if (dirInfo.GetFiles().Count() == 0 && dirInfo.GetDirectories().Count() == 0)
            {
                return;
            }

            writer.WriteStartElement("dir");
            writer.WriteStartAttribute("name", dirInfo.Name);

            foreach (var file in dirInfo.GetFiles())
            {
                writer.WriteElementString("file", file.Name);
            }

            foreach (var subDir in dirInfo.GetDirectories())
            {
                BuildXmlData(writer, subDir);
            }

            writer.WriteEndElement();
        }
    }
}