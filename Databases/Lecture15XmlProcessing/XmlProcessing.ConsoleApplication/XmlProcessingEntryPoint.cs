namespace XmlProcessing.ConsoleApplication
{
    using System;
    using System.Xml.Xsl;

    class XmlProcessingEntryPoint
    {
        private static ILogger logger;
        private static readonly string catalogPath = @"..\..\catalogue.xml";
        private static readonly string albumsgPath = @"..\..\albums.xml";
        private static readonly string personsTxt = @"..\..\persons.txt";
        private static readonly string personsXml = @"..\..\persons.xml";
        private static readonly string catalogStylesheet = @"..\..\catalogue.xslt";
        private static readonly string catalogHtml = @"..\..\catalogue.html";
        private static readonly string catalogSchema = @"..\..\catalogue.xsd";
        private static readonly string invalidCatalog = @"..\..\invalid_catalogue.xml";

        static void Main()
        {
            logger = new ConsoleLogger();
            bool isInMenu = true;
            string menuMessage = "(Task 2) Press 2 to extract artists from catalog with DomParser"
                + "\n(Task 3) Press 3 to extract artists from catalog with Xpath"
                + "\n(Task 4) Press 4 to delete albums with price > 20. (The result is saved in another file catalogue_deleted.xml"
                + "\n(Task 5) Press 5 to extract all song titles with XmlReader"
                + "\n(Task 6) Press 6 to extract all song titles with XDocument"
                + "\n(Task 7) Press 7 to create persons.xml from persons.txt"
                + "\n(Task 8) Press 8 to create album.xml"
                + "\n(Task 9) Press 9 to traverse directory and write with XmlWriter"
                + "\n(Task 10) Press a to traverse directory and write with Xdocument"
                + "\n(Task 11) Press b to extract album prices from catalogue.xml with Xpath"
                + "\n(Task 12) Press c to extract album prices from catalogue.xml with Linq"
                + "\n(Task 14) Press d apply xslt styleshit"
                + "\n(Task 16) Press e validate catalogue.xml agains schema";


            var xmlDomParser = new XmlDomParser(logger, catalogPath);
            var xmlStaxParser = new XmlStaxParser(logger);
            var xmlToLinqParser = new XmlToLinqParser(logger);
            var path = string.Empty;
            var directoryName = string.Empty;
            var outputPath = string.Empty;

            do
            {
                logger.MenuMessage(menuMessage);
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        logger.Message("Artists List:");
                        xmlDomParser.GetArtistsFromCatalogue();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        logger.Message("Artists List:");
                        xmlDomParser.GetArtistsFromCatalogueWithXpath();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        logger.ProcessingMessage("Try to delete albums with price above 20");
                        xmlDomParser.DeleteAlbums();
                        logger.SuccessMessage("Artists successfully deleted and saved in catalogue_deletex.xml");
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        logger.Message("Song Titles:");
                        xmlStaxParser.ReadAllSongTitles(catalogPath);
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        logger.Message("Song Titles:");
                        xmlToLinqParser.ReadAllSongTitles(catalogPath);
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        logger.ProcessingMessage("Creating Persons file");
                        xmlStaxParser.CreatePersonsFile(personsTxt, personsXml);
                        logger.SuccessMessage("persons.xml created successfully.");
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        logger.ProcessingMessage("Creating Albums file");
                        xmlStaxParser.CreateAlbumsFile(catalogPath, albumsgPath);
                        logger.SuccessMessage("albums.xml created successfully.");
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        logger.Message("Enter Directory path");
                        path = Console.ReadLine();
                        directoryName = path.Substring(path.LastIndexOf('\\') + 1);
                        outputPath = @"..\..\directory_" + directoryName + ".xml";
                        logger.ProcessingMessage("Creating directory listing file");
                        xmlStaxParser.TraverseDirectory(path, outputPath);
                        logger.SuccessMessage(directoryName + ".xml created successfully.");
                        break;
                    case ConsoleKey.A:
                        logger.Message("Enter Directory path");
                        path = Console.ReadLine();
                        directoryName = path.Substring(path.LastIndexOf('\\') + 1);
                        outputPath = @"..\..\directory_" + directoryName + ".xml";
                        logger.ProcessingMessage("Creating directory listing file");
                        xmlToLinqParser.TraverseDirectory(path, outputPath);
                        logger.SuccessMessage(directoryName + ".xml created successfully.");
                        break;
                    case ConsoleKey.B:
                        logger.Message("Album's prices (albums published before 40 years or more):");
                        xmlDomParser.GetLatestAlbums(40);
                        break;
                    case ConsoleKey.C:
                        logger.Message("Album's prices (albums published before 40 years or more):");
                        xmlToLinqParser.GetLatestAlbums(catalogPath, 40);
                        break;
                    case ConsoleKey.D:
                        logger.ProcessingMessage("Starting transformation to html");
                        var myXslTrans = new XslCompiledTransform();
                        myXslTrans.Load(catalogStylesheet);
                        myXslTrans.Transform(catalogPath, catalogHtml);
                        logger.SuccessMessage("Transformation completed successfully");
                        break;
                    case ConsoleKey.E:
                        logger.ProcessingMessage("Try validating catalogue.xml");
                        xmlToLinqParser.Validate(catalogPath, catalogSchema);
                        logger.ProcessingMessage("Try validating invalid_catalogue.xml");
                        xmlToLinqParser.Validate(invalidCatalog, catalogSchema);                        
                        break;
                    case ConsoleKey.Escape:
                        isInMenu = false;
                        break;
                    default:
                        logger.ErrorMessage("Incorrect input. Please try again!");
                        break;
                }
            }
            while (isInMenu);
        }
    }
}
