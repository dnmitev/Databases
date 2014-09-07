namespace Bookstore.Utilities
{
    using Bookstore.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public abstract class XmlDataParser
    {
        private BookstoreData data;
        private string pathToFile;

        public XmlDataParser(BookstoreData data, string pathToFile)
        {
            this.Data = data;
            this.PathToFile = pathToFile;
        }

        protected BookstoreData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        protected string PathToFile
        {
            get
            {
                return this.pathToFile;
            }
            set
            {
                this.pathToFile = value;
            }
        }

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