namespace XmlProcessing.ConsoleApplication
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class XmlToLinqParser
    {
        private ILogger logger;

        public XmlToLinqParser(ILogger logger)
        {
            this.logger = logger;
        }

        public void ReadAllSongTitles(string documentName)
        {
            XDocument xmlDoc = XDocument.Load(documentName);

            var songs = xmlDoc.Descendants("title");
            foreach (var song in songs)
            {
                logger.Message("Song: " + song.Value);
            }
        }


        public void TraverseDirectory(string directoryPath, string outputFile)
        {
            var document = WriteDirectory(directoryPath);
            document.Save(outputFile);
        }

        private XElement WriteDirectory(string directory)
        {
            var directoryName = directory.Substring(directory.LastIndexOf('\\') + 1);
            XElement currentDirectory = new XElement("dir", new XAttribute("name", directoryName));

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Substring(file.LastIndexOf('\\') + 1);
                XElement currentFile = new XElement("file", fileName);
                currentDirectory.Add(currentFile);
            }

            try
            {
                var dir = Directory.EnumerateDirectories(directory);
                foreach (var subDirectory in dir)
                {
                    currentDirectory.Add(WriteDirectory(subDirectory));
                }
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }

            return currentDirectory;
        }


        public void GetLatestAlbums(string documentName, int years)
        {
            var currentYear = DateTime.Now.Year;
            var yearToSearchFrom = currentYear - years;
            XDocument xmlDoc = XDocument.Load(documentName);
            var albums = xmlDoc.Descendants("album").Where(x => int.Parse(x.Descendants("year").First().Value) <= yearToSearchFrom)
                .Select(a => new
                {
                    Name = a.Descendants("name").FirstOrDefault().Value,
                    Price = a.Descendants("price").FirstOrDefault().Value,
                    Year = a.Descendants("year").FirstOrDefault().Value
                });

            foreach (var album in albums)
            {
                logger.Message(String.Format("Album: {0}, price: {1}, year: {2}", album.Name, album.Price, album.Year));
            }
        }

        public void Validate(string xmlDocument, string xsdDocument)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("", xsdDocument);
            XDocument document = XDocument.Load(xmlDocument);
            var errorCount = 0;
            document.Validate(schemas, (o, e) =>
                {
                    errorCount++;
                    logger.ErrorMessage(e.Message);
                });
            if (errorCount == 0)
            {
                logger.SuccessMessage("Document successfully validated");
            }
            else
            {
                logger.ErrorMessage(String.Format("Document is not valid. {0} errors found.",errorCount));

            }
        }
    }
}
