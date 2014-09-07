namespace XmlProcessing.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class XmlDomParser
    {
        private ILogger logger;

        private XmlDocument document;

        private string documentName;

        public XmlDomParser(ILogger logger, string document)
        {
            this.logger = logger;
            this.documentName = document;
            this.document = new XmlDocument();
            this.document.Load(document);
        }

        public void GetArtistsFromCatalogue()
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            var root = this.document.DocumentElement;

            foreach(XmlNode node in root.ChildNodes)
            {
                var artist = node["artist"].InnerText;
                if(artists.ContainsKey(artist))
                {
                    artists[artist]++;
                }
                else
                {
                    artists.Add(artist,1);
                }
            }

            foreach(var artist in artists)
            {
                logger.Message(String.Format("Artist {0} has {1} albums in catalog",artist.Key,artist.Value));
            }
        }

        public void GetArtistsFromCatalogueWithXpath()
        {
            Dictionary<string, int> artists = new Dictionary<string, int>();
            var query = "/catalogue/album/artist";
            var nodelist = this.document.SelectNodes(query);

            foreach(XmlNode node in nodelist)
            {
                var artist = node.InnerText;
                if(artists.ContainsKey(artist))
                {
                    artists[artist]++;
                }
                else
                {
                    artists.Add(artist,1);
                }
            }
            foreach(var artist in artists)
            {
                logger.Message(String.Format("Artist {0} has {1} albums in catalog",artist.Key,artist.Value));
            }
        }

        public void DeleteAlbums()
        {
            var query = "/catalogue/album[price > 20]";

            var nodeList = this.document.SelectNodes(query);
            foreach(XmlNode node in nodeList)
            {
                node.ParentNode.RemoveChild(node);
            }
            var newDocumentName = this.documentName.Replace(".xml","_deleted.xml");
            this.document.Save(newDocumentName);
        }

        public void GetLatestAlbums(int years)
        {
            var currentYear = DateTime.Now.Year;
            var yearToSearchFrom = currentYear - years;
            var query = "/catalogue/album[year<="+yearToSearchFrom+"]";
            var nodelist = this.document.SelectNodes(query);

            foreach(XmlNode node in nodelist)
            {
                var name = node.SelectSingleNode("name").InnerText;
                var price = node.SelectSingleNode("price").InnerText;
                var year = node.SelectSingleNode("year").InnerText;

                logger.Message(String.Format("Album: {0}, price: {1}, year: {2}",name,price,year));

            }
        }

    }
}
