using System;
using System.Collections.Generic;

class WordDocument:OfficeDocument,IEncryptable,IEditable
{
    public int? Chars { get; protected set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }

    public bool IsEncrypted { get ; set; }

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
        return "WordDocument[" + PropertiesToString() + "]";
    }

    
}

