using System;
using System.Collections.Generic;

class PDFDocument : BinaryDocument,IEncryptable
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
        return "PDFDocument[" + PropertiesToString() + "]";
    }
}

