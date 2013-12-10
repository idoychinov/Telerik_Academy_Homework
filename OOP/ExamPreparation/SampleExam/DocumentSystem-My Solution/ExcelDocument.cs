using System;
using System.Collections.Generic;

class ExcelDocument : OfficeDocument,IEncryptable
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
        else if(key == "cols")
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
        return "ExcelDocument[" + PropertiesToString() + "]";
    }
}

