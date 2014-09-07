namespace XmlProcessing.ConsoleApplication
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class XmlStaxParser
    {
        private ILogger logger;

        public XmlStaxParser(ILogger logger)
        {
            this.logger = logger;
        }

        public void ReadAllSongTitles(string documentName)
        {
            using (XmlReader reader = XmlReader.Create(documentName))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        logger.Message("Song: " + reader.ReadInnerXml());
                    }
                }
            }
        }

        public void CreateAlbumsFile(string documentName, string outputFile)
        {
            using (XmlTextWriter writer = new XmlTextWriter(outputFile, Encoding.UTF8))
            using (XmlReader reader = XmlReader.Create(documentName))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                string currentName = string.Empty;
                string currentAuthor = string.Empty;
                var prologWriten = false;
                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        currentName = reader.ReadInnerXml();
                    }
                    else if (reader.Name == "artist")
                    {
                        currentAuthor = reader.ReadInnerXml();
                    }

                    if (currentName != string.Empty && currentAuthor != string.Empty)
                    {
                        if (!prologWriten)
                        {
                            writer.WriteStartDocument();
                            writer.WriteStartElement("albums");
                            prologWriten = true;
                        }
                        writer.WriteStartElement("album");
                        writer.WriteElementString("name", currentName);
                        writer.WriteElementString("author", currentAuthor);
                        writer.WriteEndElement();
                        currentName = string.Empty;
                        currentAuthor = string.Empty;
                    }
                }
                writer.WriteEndElement();
            }

        }

        public void CreatePersonsFile(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (XmlTextWriter writer = new XmlTextWriter(outputFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.WriteStartDocument();
                writer.WriteStartElement("persons");

                var counter = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var currentElementLine = counter % 3;
                    switch (currentElementLine)
                    {
                        case 0:
                            writer.WriteStartElement("person");
                            writer.WriteElementString("name", line);
                            break;
                        case 1:
                            writer.WriteElementString("address", line);
                            break;
                        case 2:
                            writer.WriteElementString("phone", line);
                            writer.WriteEndElement();
                            break;
                        default:
                            throw new InvalidOperationException("Invalid number of lines");
                    }
                    counter++;
                }

                if (counter % 3 != 0)
                {
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    throw new InvalidOperationException("Invalid number of lines");
                }

                writer.WriteEndElement();
            }
        }

        public void TraverseDirectory(string directoryPath, string outputFile)
        {
            var writer = new XmlTextWriter(outputFile, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;

            using (writer)
            {
                writer.WriteStartDocument();
                WriteDirectory(directoryPath, writer);
            }
        }

        private void WriteDirectory(string directory, XmlWriter writer)
        {

            writer.WriteStartElement("dir");
            var directoryName = directory.Substring(directory.LastIndexOf('\\') + 1);
            writer.WriteAttributeString("name", directoryName);

            foreach (var file in Directory.EnumerateFiles(directory))
            {
                var fileName = file.Substring(file.LastIndexOf('\\') + 1);
                writer.WriteElementString("file", fileName);
            }

            try
            {
                var dir = Directory.EnumerateDirectories(directory);
                foreach (var subDirectory in dir)
                {
                    WriteDirectory(subDirectory, writer);
                }
            }
            catch (Exception e)
            {
                logger.ErrorMessage(e.Message);
            }
            writer.WriteEndElement();
        }
    }
}
