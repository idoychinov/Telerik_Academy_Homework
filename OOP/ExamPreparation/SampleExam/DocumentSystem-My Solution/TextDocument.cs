using System;

class TextDocument : Document
{
    public TextDocument(string name)
        : base(name)
    {
    }

    public string Charset { get; protected set; }

}

