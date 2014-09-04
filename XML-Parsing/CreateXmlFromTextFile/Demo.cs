// 07. In a text file we are given the name, address and phone number of given person (each at a single line). Write a program,
// which creates new XML document, which contains these data in structured XML format.

namespace CreateXmlFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    internal class Demo
    {
        private static void Main()
        {
            var personData = RetrieveDataFromTextFile();

            WriteDataToXml(personData);
        }
 
        private static void WriteDataToXml(Dictionary<string, string> personData)
        {
            string fileName = "../../PersonInfo.xml";
            Encoding encoding = Encoding.UTF8;
            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);

            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("info");
             
                foreach (var person in personData)
                {
                    writer.WriteElementString(person.Key, person.Value);
                }

                writer.WriteEndElement();
            }
        }
 
        private static Dictionary<string, string> RetrieveDataFromTextFile()
        {
            var person = new Dictionary<string, string>();
            var reader = new StreamReader("../../Person.txt");

            using (reader)
            {
                string name = reader.ReadLine();
                string address = reader.ReadLine();
                string phone = reader.ReadLine();

                person.Add("name", name);
                person.Add("address", address);
                person.Add("phone", phone);
            }

            return person;
        }
    }
}