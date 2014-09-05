// 09. Write a program to traverse given directory and write to a XML file its contents together with all subdirectories and files.
//Use tags <file> and <dir> with appropriate attributes. For the generation of the XML document use the class XmlWriter.

namespace FolderDataToXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class Demo
    {
        static void Main()
        {
            string folderPath = "../../";
            string outputXml = "../../folderData.xml";

            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            Encoding encoding = Encoding.UTF8;

            using (XmlTextWriter writer = new XmlTextWriter(outputXml,encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");

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

            writer.WriteStartElement("directory");
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
