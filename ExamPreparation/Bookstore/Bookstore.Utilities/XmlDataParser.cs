namespace Bookstore.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using Bookstore.Data;

    public abstract class XmlDataParser
    {
        public XmlDataParser(BookstoreData data, string pathToFile)
        {
            this.Data = data;
            this.PathToFile = pathToFile;
        }

        protected BookstoreData Data { get; set; }

        protected string PathToFile { get; set; }

        public abstract void ParseFile();

        protected string GetSingleValue(string tag, XElement item)
        {
            if (item != null)
            {
                var result = item.Element(tag);
                if (result != null)
                {
                    return result.Value;
                }
            }

            return null;
        }

        protected ISet<string> GetMultipleValues(string tag, XElement itemsCollection)
        {
            var resultSet = new HashSet<string>();

            if (itemsCollection != null)
            {
                foreach (var element in itemsCollection.Elements(tag))
                {
                    resultSet.Add(element.Value);
                }
            }

            return resultSet;
        }
    }
}