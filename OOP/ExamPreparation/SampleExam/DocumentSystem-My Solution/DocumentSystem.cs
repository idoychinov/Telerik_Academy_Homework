using System;
using System.Collections.Generic;
using System.Linq;

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}

public class DocumentSystem
{
    private static List<Document> allDocuments;
    static void Main()
    {
        allDocuments = new List<Document>();
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        Document currentDocument = CreateDocument(typeof(TextDocument),attributes); 
        allDocuments.Add(currentDocument);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        Document currentDocument = CreateDocument(typeof(PDFDocument), attributes);
        allDocuments.Add(currentDocument);
    }

    private static void AddWordDocument(string[] attributes)
    {
        // TODO
    }

    private static void AddExcelDocument(string[] attributes)
    {
        // TODO
    }

    private static void AddAudioDocument(string[] attributes)
    {
        // TODO
    }

    private static void AddVideoDocument(string[] attributes)
    {
        // TODO
    }

    private static void ListDocuments()
    {
        // TODO
    }

    private static void EncryptDocument(string name)
    {
        // TODO
    }

    private static void DecryptDocument(string name)
    {
        // TODO
    }

    private static void EncryptAllDocuments()
    {
        // TODO
    }

    private static void ChangeContent(string name, string content)
    {
        // TODO
    }

    private static IDictionary<string,string> SeparateAttributes(string[] attributes)
    {
        var result = attributes.Select(pair => pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(pair=>pair[0],pair=>pair[1]);
        return result;
    }

    private static Document CreateDocument(Type documentType, string[] attributes)
    {
        var parameters = SeparateAttributes(attributes);
        Document createdDocument;
        if (documentType==typeof(TextDocument))
        {
            createdDocument = new TextDocument(parameters["name"]);   
        }
        else if (documentType == typeof(TextDocument))
        {
            createdDocument = new PDFDocument(parameters["name"]);
        }
        else
        {
            throw new ArgumentException("Cann't create document of type "+documentType.Name 
                +". Type is not defined CreateDocument method."); 
        }
        
        parameters.Remove("name");
        foreach (var parameter in parameters)
        {
            var keyAsCharArray = parameter.Key.ToCharArray();
            keyAsCharArray[0] = char.ToUpper(keyAsCharArray[0]);
            createdDocument.LoadProperty(keyAsCharArray.ToString(), parameter.Value);
        }

        return createdDocument;
    }
}
