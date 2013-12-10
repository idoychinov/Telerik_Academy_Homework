using System;
using System.Collections.Generic;

class VideoDocument : MultimediaDocument
{
    public int? FrameRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        base.LoadProperty(key, value);
        if (key == "framerate")
        {
            this.FrameRate = int.Parse(value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
    }

    public override string ToString()
    {
        return "VideoDocument[" + PropertiesToString() + "]";
    }
}

