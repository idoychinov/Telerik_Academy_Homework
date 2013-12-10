using System;
using System.Collections.Generic;

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

