using System;
using System.Collections.Generic;
using System.Reflection;

public abstract class Document : IDocument
{

    public Document(string name)
    {
        this.Name = name;
    }

    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
   {
        var properties = this.GetType().GetProperty(key);
        properties.SetValue(this, value);
        
        //if (key == "content")
        //{
        //    this.Content = value;
        //}
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        string output = string.Empty;
        var properties = this.GetType().GetProperties();

        return output;
    }
}

