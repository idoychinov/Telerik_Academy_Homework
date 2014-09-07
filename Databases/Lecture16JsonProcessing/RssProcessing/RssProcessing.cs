namespace RssProcessing
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class RssProcessing
    {
        private const string rssFeedUrl = "http://forums.academy.telerik.com/feed/qa.rss";
        private const string feedXml = @"..\..\Files\feed.xml";
        private const string feedJson = @"..\..\Files\feed.json";
        private const string feedHtml = @"..\..\Files\feed.html";
        
        static void Main()
        {
            // Task 1. The RSS feed is at http://forums.academy.telerik.com/feed/qa.rss 
            var webClient = new WebClient();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            // Task 2. Download the content of the feed programmatically. You can use WebClient.DownloadFile()
            Console.WriteLine("Reading RSS feed from" + rssFeedUrl);
            webClient.DownloadFile(rssFeedUrl, feedXml);
            Console.WriteLine("RSS feed downloaded successfully to local file " + feedXml);

            // Task 3. Parse the XML from the feed to JSON
            Console.WriteLine("Reading RSS feed XML file and converting it to JSON");
            var xmlFeed = XDocument.Load(feedXml);
            var jsonFeed = JsonConvert.SerializeXNode(xmlFeed, Formatting.Indented);

            // Additional step to save localy the json version of the feed
            Console.WriteLine("JSON conversion complete. Writing to local file" + feedJson);
            File.WriteAllText(feedJson, jsonFeed);
            Console.WriteLine("JSON file save complete.");

            // Task 4. Using LINQ-to-JSON select all the question titles and print them to the console
            var jsonObject = JObject.Parse(jsonFeed);
            var titles = jsonObject["rss"]["channel"]["item"].Select(x => x["title"]);
            Console.WriteLine("All titles:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Join(Environment.NewLine, titles));
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Task 5. Parse JSON to POCO
            Console.WriteLine("Parsing JSON to POCO:");

            var itemsJson = jsonObject["rss"]["channel"]["item"].ToString();
            var template = new[]
            {   
                new {
                    Title = "",
                    Link = "",
                    Description = "",
                    Category = "",
                    PubDate = ""
                }
            };
            var items = JsonConvert.DeserializeAnonymousType(itemsJson, template);
            Console.WriteLine("Parsing successful");

            // Task 6. Generate Html
            Console.WriteLine("Generating HTML file");

            var htmlContent = new StringBuilder();
            htmlContent.AppendLine("<html>");
            htmlContent.AppendLine("\t<body>");
            htmlContent.AppendLine("\t<h1>Items</h1>");
            htmlContent.AppendLine("\t\t<table>");
            htmlContent.AppendLine("\t\t\t<tr><th>Category</th><th>Question</th></tr>");


            foreach(var item in items)
            {
            htmlContent.AppendLine("\t\t\t<tr><td>"+item.Category+"</td><td><a href="+item.Link+">"+item.Title+"</a></td></tr>");

            }
            htmlContent.AppendLine("\t\t</table>");
            htmlContent.AppendLine("\t</body>");
            htmlContent.AppendLine("</html>");


            File.WriteAllText(feedHtml, htmlContent.ToString(),Encoding.UTF8);
            Console.WriteLine("Html file generation successful");

        }
    }
}
