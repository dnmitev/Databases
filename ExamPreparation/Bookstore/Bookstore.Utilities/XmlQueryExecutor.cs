namespace Bookstore.Utilities
{
    using Bookstore.Data;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class XmlQueryExecutor
    {
        private BookstoreData data;
        private string inputFilePath;
        private string outputFilePath;

        public XmlQueryExecutor(BookstoreData data, string inputFilePath, string outputFilePath)
        {
            this.data = data;
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
        }

        public void ExecuteQueries()
        {
            var streamReader = new StreamReader(this.inputFilePath, Encoding.UTF8);
            var queryElements = XElement.Load(streamReader).Elements();

            var outputXml = new XElement("search-results");
            var resultSet = new XElement("result-set");

            foreach (var query in queryElements)
            {
                var queryType = query.Attribute("type").Value;
                if (queryType == "by-period")
                {
                    //this.ProcessPeriodQuery(query, resultSet);
                }
                else if (queryType == "by-author")
                {
                    this.ProcessAuthorQuery(query, resultSet);
                }
                else
                {
                    throw new ArgumentException("Invalid query!.");
                }
            }

            outputXml.Add(resultSet);
            outputXml.Save(this.outputFilePath);
        }

        private void ProcessAuthorQuery(XElement query, XElement resultSet)
        {
            var authorName = query.Element("author-name").Value;

            var reviewResult = this.data.Reviews.All()
                .Where(r => r.Author.Name == authorName)
                .OrderBy(r => r.CreationDate)
                .ThenBy(r => r.Content)
                .ToList();

            foreach (var review in reviewResult)
            {
                var reviewElement = new XElement("review");

                var dateElement = new XElement("date");
                dateElement.Value = review.CreationDate.ToString("d-MMM-yyyy");

                var contentElement = new XElement("content");
                contentElement.Value = review.Content;
                reviewElement.Add(contentElement);

                var bookElement = new XElement("book");

                var titleElement = new XElement("title");
                titleElement.Value = review.Book.Title;
                bookElement.Add(titleElement);

                var authorsElement = new XElement("authors");
                authorsElement.Value = string.Join(", ", review.Book.Authors);
                bookElement.Add(authorsElement);

                if (review.Book.ISBN != null)
                {
                    var isbnElement = new XElement("isbn");
                    isbnElement.Value = review.Book.ISBN;
                    bookElement.Add(isbnElement);
                }

                if (review.Book.WebSite != null)
                {
                    var websiteElement = new XElement("website");
                    websiteElement.Value = review.Book.WebSite;
                    bookElement.Add(websiteElement);
                }

                reviewElement.Add(bookElement);
                resultSet.Add(reviewElement);
            }
        }

        private void ProcessPeriodQuery(XElement query, XElement resultSet)
        {
            throw new NotImplementedException();
        }
    }
}