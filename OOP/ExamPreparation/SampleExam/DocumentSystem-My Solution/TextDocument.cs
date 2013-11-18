using System;
using System.Collections.Generic;


public class TextDocument : Document
{
    public TextDocument(string name)
        : base(name)
    {
    }

    public string Charset { get; protected set; }

    //public override void LoadProperty(string key, string value)
    //{
    //    base.LoadProperty(key, value);
    //}

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

