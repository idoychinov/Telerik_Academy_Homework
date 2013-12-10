using System;
using System.Collections.Generic;

abstract class  OfficeDocument : BinaryDocument
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

