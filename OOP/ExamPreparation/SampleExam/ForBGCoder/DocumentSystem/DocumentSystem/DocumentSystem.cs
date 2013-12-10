using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace test
{
    class AudioDocument : MultimediaDocument
    {
        public int? Samplerate { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "samplerate")
            {
                this.Samplerate = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.Samplerate));
        }

        public override string ToString()
        {
            return "AudioDocument[" + PropertiesToString() + "]";
        }
    }

    abstract class BinaryDocument : Document
    {
        public long? Size { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "size")
            {
                this.Size = long.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }

    }

    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            if (output == null)
            {
                throw new ArgumentNullException("Output list of properties is not defined!");
            }
            else
            {
                output.Add(new KeyValuePair<string, object>("name", this.Name));
                output.Add(new KeyValuePair<string, object>("content", this.Content));
            }

        }

        public override string ToString()
        {
            return PropertiesToString();
        }

        protected virtual string PropertiesToString()
        {
            List<KeyValuePair<string, object>> allProperties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(allProperties);
            allProperties.Sort(DocumentSystem.CompareAttributes);
            StringBuilder output = new StringBuilder();
            foreach (var property in allProperties)
            {
                if (property.Value != null)
                {
                    output.Append(property.Key + "=" + property.Value + ";");
                }
            }
            output.Remove(output.Length - 1, 1);
            return output.ToString();
        }
    }


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

    enum ChangeType { Encript, Decript, Edit };

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
            CreateDocument(typeof(TextDocument), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            CreateDocument(typeof(PDFDocument), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            CreateDocument(typeof(WordDocument), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            CreateDocument(typeof(ExcelDocument), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            CreateDocument(typeof(AudioDocument), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            CreateDocument(typeof(VideoDocument), attributes);
        }

        private static void ListDocuments()
        {
            foreach (Document document in allDocuments)
            {
                Console.WriteLine(document.ToString());
            }
        }

        private static void EncryptDocument(string name)
        {
            ChangeDocument(name, ChangeType.Encript, string.Empty);
        }



        private static void DecryptDocument(string name)
        {
            ChangeDocument(name, ChangeType.Decript, string.Empty);
        }

        private static void EncryptAllDocuments()
        {
            int encryptedDocuments = 0;
            foreach (var document in allDocuments)
            {
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Encrypt();
                    encryptedDocuments++;
                }
            }

            if (encryptedDocuments == 0)
            {
                Console.WriteLine("No encryptable documents found");
            }
            else
            {
                Console.WriteLine("All documents encrypted");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            ChangeDocument(name, ChangeType.Edit, content);
        }

        private static IDictionary<string, string> SeparateAttributes(string[] attributes)
        {
            var result = attributes.Select(pair => pair.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(pair => pair[0], pair => pair[1]);
            return result;
        }

        private static bool hasName(IDictionary<string, string> attributes)
        {
            if (attributes.ContainsKey("name"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateDocument(Type documentType, string[] attributes)
        {
            IDictionary<string, string> nameValueAtributePairs = SeparateAttributes(attributes);
            if (hasName(nameValueAtributePairs))
            {
                string name = nameValueAtributePairs["name"];

                Document currentDocument = (dynamic)Activator.CreateInstance(documentType);

                foreach (var attribute in nameValueAtributePairs)
                {
                    currentDocument.LoadProperty(attribute.Key, attribute.Value);
                }
                allDocuments.Add(currentDocument);
                Console.WriteLine("Document added: {0}", name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        internal static int CompareAttributes(KeyValuePair<string, object> a, KeyValuePair<string, object> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        private static void ChangeDocument(string name, ChangeType typeOfChange, string content)
        {
            List<Document> documentsWithSameName = allDocuments.FindAll(delegate(Document doc)
            {
                if (doc.Name == name)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });

            if (documentsWithSameName.Count == 0)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
            foreach (var document in documentsWithSameName)
            {
                string message = string.Empty;
                switch (typeOfChange)
                {
                    case ChangeType.Decript:
                        if (document is IEncryptable)
                        {
                            message = "Document decrypted: " + name; (document as IEncryptable).Decrypt();
                        }
                        else
                        {
                            message = "Document does not support decryption: " + name;
                        }
                        break;
                    case ChangeType.Encript:
                        if (document is IEncryptable)
                        {
                            message = "Document encrypted: " + name; (document as IEncryptable).Encrypt();
                        }
                        else
                        {
                            message = "Document does not support encryption: " + name; break;
                        }
                        break;
                    case ChangeType.Edit:
                        if (document is IEditable)
                        {
                            message = "Document content changed: " + name; (document as IEditable).ChangeContent(content);
                        }
                        else
                        {
                            message = "Document is not editable: " + name;
                        }
                        break;
                    default: throw new ArgumentException();
                }
                Console.WriteLine(message);


            }
        }
    }

    class ExcelDocument : OfficeDocument, IEncryptable
    {
        public int? Rows { get; protected set; }
        public int? Cols { get; protected set; }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "rows")
            {
                this.Rows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.Cols = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("colss", this.Cols));
        }

        public override string ToString()
        {
            if (IsEncrypted)
            {
                return "ExcelDocument[encrypted]";
            }
            return "ExcelDocument[" + PropertiesToString() + "]";
        }
    }


    abstract class MultimediaDocument : BinaryDocument
    {
        public int? Length { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "length")
            {
                this.Length = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }

    }


    abstract class OfficeDocument : BinaryDocument
    {
        public string Version { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "version")
            {
                this.Version = value;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }

    }

    class PDFDocument : BinaryDocument, IEncryptable
    {
        public int? Pages { get; protected set; }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "pages")
            {
                this.Pages = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }

        public override string ToString()
        {
            if (IsEncrypted)
            {
                return "PDFDocument[encrypted]";
            }
            return "PDFDocument[" + PropertiesToString() + "]";
        }
    }


    class TextDocument : Document, IEditable
    {
        public string Charset { get; protected set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "charset")
            {
                this.Charset = value;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }

        public override string ToString()
        {
            return "TextDocument[" + PropertiesToString() + "]";
        }

    }


    class VideoDocument : MultimediaDocument
    {
        public int? FrameRate { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "framerate")
            {
                this.FrameRate = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }

        public override string ToString()
        {
            return "VideoDocument[" + PropertiesToString() + "]";
        }
    }



    class WordDocument : OfficeDocument, IEncryptable, IEditable
    {
        public int? Chars { get; protected set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

        public override void LoadProperty(string key, string value)
        {
            base.LoadProperty(key, value);
            if (key == "chars")
            {
                this.Chars = int.Parse(value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        }

        public override string ToString()
        {
            if (IsEncrypted)
            {
                return "WordDocument[encrypted]";
            }
            return "WordDocument[" + PropertiesToString() + "]";
        }


    }


}