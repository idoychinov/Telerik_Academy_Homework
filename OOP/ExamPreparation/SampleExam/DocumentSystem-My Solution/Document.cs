using System;
using System.Collections.Generic;
using System.Text;

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
            this.Content =value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if(output==null)
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

