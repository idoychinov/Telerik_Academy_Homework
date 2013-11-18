using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
        var property = this.GetType().GetProperty(key);
        property.SetValue(this, value);
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        var properties = this.GetType().GetProperties();
        foreach (var property in properties)
        {
            var name = property.Name.ToLower();
            var value = property.GetValue(this);
            output.Add(new KeyValuePair<string, object>(name, value));
        }
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        return output.ToString();
    }
}

