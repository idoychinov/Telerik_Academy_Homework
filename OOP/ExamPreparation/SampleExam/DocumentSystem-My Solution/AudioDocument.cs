using System;
using System.Collections.Generic;

class AudioDocument : MultimediaDocument
{
    public int? Samplerate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "samplerate")
        {
            this.Samplerate = int.Parse(value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("samplerate", this.Samplerate));
    }

    public override string ToString()
    {
        return "AudioDocument[" + PropertiesToString() + "]";
    }
}

