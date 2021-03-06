﻿using System;
using System.Collections.Generic;

abstract class BinaryDocument : Document
{
    public long? Size { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "size")
        {
            this.Size = long.Parse(value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("size", this.Size));
    }

}

