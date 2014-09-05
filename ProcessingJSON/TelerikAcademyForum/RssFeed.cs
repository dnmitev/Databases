// Using JSON.NET and the Telerik Academy Forums RSS feed implement the following:

// The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
// Download the content of the feed programmatically
// You can use WebClient.DownloadFile()
// Parse the XML from the feed to JSON
// Using LINQ-to-JSON select all the question titles and print them to the console
// Parse the JSON string to POCO
// Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question's page

namespace TelerikAcademyForum
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.IO;

    class RssFeed
    {
        static void Main()
        {
            DownloadRssFeed();

            var jsonData = GetJsonFromXml();

            PrintTitles(jsonData);

            var qaList = GetQuestionList(jsonData);
            GenerateHtmlPage(qaList);
        }

        private static void GenerateHtmlPage(List<Question> qaList)
        {
            using (var writer = new StreamWriter("../../queastions.html",false,Encoding.UTF8))
            {
                foreach (var question in qaList)
                {
                    writer.WriteLine("<div>");

                    writer.WriteLine("<h1>Question: {0}</h1>", question.Title);
                    writer.WriteLine("<p>Category: {0}</p>", question.Category);
                    writer.WriteLine("<p>Description: {0}</p>", question.Description);
                    writer.WriteLine("<a href=\"{0}\">Go to question</a>", question.Link);

                    writer.WriteLine("</div>");
                }
            }
        }

        private static List<Question> GetQuestionList(string jsonData)
        {
            var jsonObj = JObject.Parse(jsonData);

            var qaList = jsonObj["channel"]["item"]
                .Select(x => new Question()
                {
                    Title = x["title"].ToString(),
                    Description = x["description"].ToString(),
                    Category = x["category"].ToString(),
                    Link = x["link"].ToString()
                })
                .ToList();

            return qaList;
        }

        private static void PrintTitles(string jsonData)
        {
            var jsonObj = JObject.Parse(jsonData);

            var titles = jsonObj["channel"]["item"]
                .Select(x => x["title"]);

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        private static string GetJsonFromXml()
        {
            string pathToXml = "../../telerik-academy-forum-rss.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(pathToXml);

            string jsonFile = JsonConvert.SerializeObject(xmlDoc.DocumentElement.FirstChild);

            return jsonFile;
        }
 
        private static void DownloadRssFeed()
        {
            var webClient = new WebClient();
            string rssUrl = "http://forums.academy.telerik.com/feed/qa.rss";
            webClient.DownloadFile(rssUrl, "../../telerik-academy-forum-rss.xml");
        }
    }
}
