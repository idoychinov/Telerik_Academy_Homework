using System;
using System.Collections.Generic;

class TextDocument : Document,IEditable
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

